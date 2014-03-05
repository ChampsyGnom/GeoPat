using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Controls;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Presentation.Views;
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
                views.Add(new GenericDataGridView());   
                views.Add(new GenericDataFormView());                
                return views;
            }
            return base.GetEntityViews(tableInfo);
        }
        
    }
}
