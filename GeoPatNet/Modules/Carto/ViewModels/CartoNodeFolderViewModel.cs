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

        public DelegateCommand<Object> RemoveFolderCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().RemoveFolderCommand;
            }
        }


        public DelegateCommand<Object> AddFolderCommand
        {
            get {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddFolderCommand;
            }
        }

        public DelegateCommand<Object> AddLayerGoogleMapCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerGoogleMapCommand;
            }
        }
        public DelegateCommand<Object> AddLayerGoogleSateliteCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerGoogleSateliteCommand;
            }
        }
        public DelegateCommand<Object> AddLayerGoogleTerrainCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerGoogleTerrainCommand;
            }
        }
        public DelegateCommand<Object> AddLayerBingRoadCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerBingRoadCommand;
            }
        }
        public DelegateCommand<Object> AddLayerBingHybridCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerBingHybridCommand;
            }
        }
        public DelegateCommand<Object> AddLayerBingAerialCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerBingAerialCommand;
            }
        }
        public DelegateCommand<Object> AddLayerOsmCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CartoViewModel>().AddLayerOsmCommand;
            }
        }


       
        
        public CartoNodeFolderViewModel(SigNode model)
            : base(model)
        {
            this.Nodes = new ObservableCollection<CartoNodeViewModel>();
        }

      
    }
}
