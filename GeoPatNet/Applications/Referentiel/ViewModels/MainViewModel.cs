using Emash.GeoPatNet.Engine.Implentation.ViewModels;
using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.App.Referentiel.ViewModels
{
    public class MainViewModel : MainViewModelBase
    {
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager,IUnityContainer container)
            : base(eventAggregator, regionManager, container)
        { 
            
        }
        
    }
}
