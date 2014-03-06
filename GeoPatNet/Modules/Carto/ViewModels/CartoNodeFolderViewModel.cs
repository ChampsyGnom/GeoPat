using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Data.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class CartoNodeFolderViewModel : CartoNodeViewModel
    {
        public ObservableCollection<CartoNodeViewModel> Nodes { get; private set; }
        public DelegateCommand<Object> AddFolderCommand
        {
            get {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddFolderCommand;
            }
        }
        public DelegateCommand<Object> AddLayerGoogleCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerGoogleCommand;
            }
        }
        
        public CartoNodeFolderViewModel(SigNode model)
            : base(model)
        {
            this.Nodes = new ObservableCollection<CartoNodeViewModel>();
        }

      
    }
}
