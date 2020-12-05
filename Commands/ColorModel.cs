using Commands.Comands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Commands
{
    public class ColorModel : INotifyPropertyChanged
    {

        private byte a = 0;
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;
        private Color color = Colors.White;

        public byte A
        {
            get { return a; }
            set
            {
                if (a != value)
                {
                    a = value;
                    Color = Color.FromArgb(a, r, g, b);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();


                }
            }
        }
        public ColorModel()
        {
            A = 0;
            R = 0;
            G = 0;
            B = 0;

      
        }
    
 
     

        public ColorModel Clone()
        {
            return (ColorModel)this.MemberwiseClone();
        }
        public byte R
        {
            get { return r; }
            set
            {
                if (r != value)
                {

                    r = value;
                    Color = Color.FromArgb(a, r, g, b);
                    OnPropertyChanged();


                }
            }
        }

        public byte G
        {
            get { return g; }
            set
            {
                if (g != value)
                {


                    g = value;
                    Color = Color.FromArgb(a, r, g, b);
                    OnPropertyChanged();



                }
            }
        }

        public byte B
        {
            get
            {
                return b;
            }
            set
            {
                if (b != value)
                {

                    b = value;
                    Color = Color.FromArgb(a, r, g, b);
                    OnPropertyChanged();



                }
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged();

                }

            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
