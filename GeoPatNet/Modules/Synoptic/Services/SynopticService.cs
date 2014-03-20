using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Synoptic.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Synoptic.Services
{
    public class SynopticService : ISynopticService
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        public SynopticService(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._container = container;    
        }


        public void ShowSynoptic(Type entityType, object entityObject)
        {
           
            IRegion region = this._regionManager.Regions["TabRegion"];
            SynopticBrowserView view = null;
            foreach (Object o in region.Views)
            {
                if (o is SynopticBrowserView)
                { view = o as SynopticBrowserView; }
            }
            if (view == null)
            {
                view = this._container.Resolve<SynopticBrowserView>();
                region.Add(view);
            }           
            region.Activate(view);
          
          
        }
    }
}
