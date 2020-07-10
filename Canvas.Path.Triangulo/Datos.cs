using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Canvas.Path.Triangulo
{
    public class Datos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _propiedad1;

        public Datos()
        {
            DispatcherTimer ds = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };

            ds.Tick += new EventHandler(Ticky);
            ds.Start();
        }

        private void Ticky(object sender, EventArgs e)
        {
            Random rm = new Random();
            Propiedad1 = rm.Next(1, 200);
        }

        public int Propiedad1
        {
            get
            {
                return _propiedad1;
            }
            set
            {
                if (_propiedad1 != value)
                {
                    _propiedad1 = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}