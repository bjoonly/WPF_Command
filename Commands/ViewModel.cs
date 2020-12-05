using Commands.Comands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Commands
{
    public class ViewModel : INotifyPropertyChanged
    {
        
        private Command deleteColorCommand;
        private Command addColorCommand;

        private readonly ICollection<ColorModel> colors = new ObservableCollection<ColorModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<ColorModel> Colors => colors;

       public ICommand DeleteColorCommand => deleteColorCommand;
        public ICommand AddColorCommand => addColorCommand;

        private ColorModel selectedColor;
        public ColorModel SelectedColor {
            get { return selectedColor; }
            set { 
                if (value != selectedColor ){
                    selectedColor = value;
                    OnPropertyChanged();

                } }
        }
        public ViewModel()
        {
            SelectedColor = new ColorModel();
            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(SelectedColor))
                {
                    deleteColorCommand.RaiseCanExecuteChanged();
                    addColorCommand.RaiseCanExecuteChanged();
                }
            };
            addColorCommand = new DelegateCommand(AddSelectedColor, () => colors.Contains(SelectedColor) == false);
            deleteColorCommand = new DelegateCommand(RemoveSelectedColor/*, /*()=>colors.Contains(SelectedColor) == true*/);

        }
      
        public void AddSelectedColor()
        {
            if (SelectedColor != null)
            {
                colors.Add((ColorModel)SelectedColor.Clone());
            }
         
        }

       

        public void RemoveSelectedColor()
        {
             colors.Remove(SelectedColor);
            SelectedColor = new ColorModel();

            
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
