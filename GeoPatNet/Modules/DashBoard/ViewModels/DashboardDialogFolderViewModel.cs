using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emash.GeoPatNet.Dashboard.Implementation.ViewModels
{
    public class DashboardDialogFolderViewModel : INotifyPropertyChanged
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
      
      
     
        public String Title { get; set; }
        public DashboardDialogFolderViewModel()
        {
            
            this.Title = "Ajout d'un dossier";
            this.FolderName = "Nouveau dossier";
           
        }
    }
}
