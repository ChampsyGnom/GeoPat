using Emash.GeoPatNet.Data.Implementation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public abstract class DashboardItemViewModel : INotifyPropertyChanged
    {
        public String FolderName { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
      
        public String DisplayName { get; set; }
        public InfDashboard Model { get; set; }
        private Boolean _isSelected;

        public Boolean IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; this.RaisePropertyChanged("IsSelected"); }
        }
        private Boolean _isExpanded;

        public Boolean IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; this.RaisePropertyChanged("IsExpanded"); }
        }
        
    }
}
