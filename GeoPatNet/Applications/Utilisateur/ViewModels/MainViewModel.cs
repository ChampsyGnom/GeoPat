using Emash.GeoPatNet.Engine.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class MainViewModel : MainViewModelBase
    {
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IUnityContainer container)
            : base(eventAggregator, regionManager, container)
        {



        }

      
        
    }
}
