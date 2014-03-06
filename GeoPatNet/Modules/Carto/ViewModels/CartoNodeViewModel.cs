using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public abstract class CartoNodeViewModel : INotifyPropertyChanged
    {
        public Visibility RemoveLayerVisibility
        {
            get
            {
                if (this is CartoNodeLayerViewModel)
                { return Visibility.Visible; }
                else return Visibility.Collapsed;
            }
        }
        public Visibility RemoveFolderVisibility
        {
            get
            {
                if (this is CartoNodeFolderViewModel)
                { return Visibility.Visible; }
                else return Visibility.Collapsed;
            }
        }
        public Visibility AddLayerVisibility
        {
            get {
                if (this is CartoNodeFolderViewModel)
                { return Visibility.Visible; }
                else return Visibility.Collapsed;
            }
        }
        public Visibility AddFolderVisibility
        {
            get
            {
                if (this is CartoNodeFolderViewModel)
                { return Visibility.Visible; }
                else return Visibility.Collapsed;
            }
        }
        public String DisplayName
        {
            get { return this.Model.Libelle; }
        }
        public SigNode Model { get; private set; }
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
        public CartoNodeViewModel(SigNode model)
        {
            this.Model = model;
        }
    }
}
