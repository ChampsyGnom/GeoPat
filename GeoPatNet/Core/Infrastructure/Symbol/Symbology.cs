using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Symbol
{
    public class Symbology : INotifyPropertyChanged
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
        public SymbologyRule Rule { get; set; }
        public Symbolizer Symbolizer { get; set; }
        private String _displayName;

        public String DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; this.RaisePropertyChanged("DisplayName"); }
        }
    }
}
