using Emash.GeoPatNet.Infrastructure.Enums;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Symbol
{
    public abstract class SymbologyRule : INotifyPropertyChanged
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
        private EntityFieldInfo _field;

        public EntityFieldInfo Field
        {
            get { return _field; }
            set { _field = value; this.RaisePropertyChanged("Field"); }
        }
        private Object _value;

        public Object Value
        {
            get { return _value; }
            set { _value = value; this.RaisePropertyChanged("Value"); }
        }
    }
}
