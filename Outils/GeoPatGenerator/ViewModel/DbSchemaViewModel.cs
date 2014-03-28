using Emash.GeoPat.Generator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPat.Generator.ViewModel
{
    public class DbSchemaViewModel : INotifyPropertyChanged 
    {
        public DbSchema Model { get; private set; }
        public String DisplayName { get { return this.Model.DisplayName; } }
        private Boolean _isSelected;
        public event PropertyChangedEventHandler PropertyChanged;

        public Boolean IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; this.RaisePropertyChange("IsSelected"); }
        }
        public DbSchemaViewModel(DbSchema model)
        {
            this.Model = model;
        }

        protected void RaisePropertyChange(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
