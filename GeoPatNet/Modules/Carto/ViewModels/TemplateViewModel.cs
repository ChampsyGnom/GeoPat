using Emash.GeoPatNet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CartoNodeViewModel> Nodes { get; private set; }
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
        public SigTemplate Model { get; private set; }

        public String DisplayName
        {
            get{ return this.Model.Libelle; }
        }
        public TemplateViewModel(SigTemplate model)
        {
            // TODO: Complete member initialization
            this.Model = model;
            this.Nodes = new ObservableCollection<CartoNodeViewModel>();
        }
        public void SetModel(SigTemplate model)
        {
            this.Model = model;
            this.RaisePropertyChanged("DisplayName");
        }

    }
}
