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
using System.Windows.Controls;
using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Presentation.Implementation.Views;
using Emash.GeoPatNet.App.Referentiel.Views;

namespace Emash.GeoPatNet.App.Referentiel.ViewModels
{
    public class MainViewModel : MainViewModelBase
    {
        public MainViewModel(IEventAggregator eventAggregator, IRegionManager regionManager,IUnityContainer container)
            : base(eventAggregator, regionManager, container)
        { 
            


        }

        public override List<Control> GetEntityViews(EntityTableInfo tableInfo)
        {
            if (tableInfo.EntityType .Equals (typeof(InfAire)))
            {
                List<Control> views = new List<Control>();
                views.Add(new FicheAireView());
                views.Add(new GenericDataFormView());                
                return views;
            }
            return base.GetEntityViews(tableInfo);
        }
        
    }
}
