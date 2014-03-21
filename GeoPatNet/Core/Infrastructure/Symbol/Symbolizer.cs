using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Emash.GeoPatNet.Infrastructure.Symbol
{
    public class Symbolizer : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        private Color _baseColor;

        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; this.RaisePropertyChanged("BaseColor"); }
        }

        public Symbolizer()
        {
            this.BaseColor = Colors.Beige;
        }
    }
}
