using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Infrastructure.Services;
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
    public class DashboardDialogItemViewModel : INotifyPropertyChanged
    {
        public EntityTableInfo SelectedTableInfo { get;  set; }
        public List<EntitySchemaInfo> SchemaInfos { get; private set; }
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
        public Visibility IsFolderVisibility
        {
            get
            {
                if (this._isFolder) return Visibility.Visible;
                else return Visibility.Hidden;
            }
        }
        public Visibility IsTableVisibility {
            get 
            {
                if (this._isFolder) return Visibility.Hidden;
                else return Visibility.Visible;
            } 
        }
        private Boolean _isFolder;

        public Boolean IsFolder
        {
            get { return _isFolder; }
            set 
            {
                _isFolder = value;
                this.RaisePropertyChanged("IsFolder");
                this.RaisePropertyChanged("IsTable");
                this.RaisePropertyChanged("IsTableVisibility");
                this.RaisePropertyChanged("IsFolderVisibility");
            }
        }
        public Boolean IsTable
        {
            get
            { return !IsFolder; }
            set
            { this.IsFolder = !value; }
        }
        public DashboardItemViewModel DashboardItem { get; set; }
        public String Title { get; set; }
        public DashboardDialogItemViewModel(DashboardItemViewModel dashboardItemViewModel)
        {
            this.SchemaInfos = ServiceLocator.Current.GetInstance<IDataService>().SchemaInfos;
            if (dashboardItemViewModel == null)
            {
                this.Title = "Ajout d'un élément au tableau de bord";
                this.IsFolder = true;
                this.FolderName = "Nouveau dossier";
            }
            else { this.Title = "Supression d'un élément du tableau de bord"; }
        }
    }
}
