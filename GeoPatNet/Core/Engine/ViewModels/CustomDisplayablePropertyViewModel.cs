using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class CustomDisplayablePropertyViewModel<M> : INotifyPropertyChanged
    {
        public  CustomDisplayableEntityViewModel<M>  Entity { get; set; }
        public String FieldPath { get; set; }
        public String DisplayName { get; set; }
        public EntityColumnInfo ColumnInfo { get; set; }
        public Boolean CanRemove { get; set; }
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
        internal void RaiseChange()
        {
            this.RaisePropertyChanged("FieldPath");
            this.RaisePropertyChanged("Entity");
            this.RaisePropertyChanged("CanRemove");
            this.RaisePropertyChanged("ColumnInfo");
        }
    }
}
