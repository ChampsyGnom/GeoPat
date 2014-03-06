using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.ViewModels;
using Emash.GeoPatNet.Modules.Carto.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Modules.Carto.Services
{
    public class CartoService : ICartoService
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
       
       
        public CartoService(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._container = container;
           
            this._container.RegisterType<CartoView>();
        
             
           
        }
        public void ShowCarto()
        {
            IRegion region = this._regionManager.Regions["TabRegion"];
            CartoView view = null;
            foreach (Object o in region.Views)
            {
           
                if (o is CartoView)
                { view = o as CartoView; }
                Console.WriteLine(o);
            }
            if (view == null)
            { 
                view = this._container.Resolve<CartoView>();
                region.Add(view);
            }
          
            region.Activate(view);
           if (this._container.Resolve<CartoViewModel>().TemplatesView.CurrentItem == null && this._container.Resolve<CartoViewModel>().Templates.Count > 0)
           { this._container.Resolve<CartoViewModel>().TemplatesView.MoveCurrentToFirst(); }
            
        }


        public void Initialize()
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du module cartographie ...");
            IDataService dataService = this._container.Resolve<IDataService>();
            DbSet<SigCodeLayer> codeLayers  =dataService.GetDbSet<SigCodeLayer> ();
            DbSet<SigCodeNode> codeNodes = dataService.GetDbSet<SigCodeNode>();

            DbSet<SigCodeTemplate> codeTemplates = dataService.GetDbSet<SigCodeTemplate>();

            if ((from c in codeTemplates where c.Code.Equals("Detail") select c).Any() == false)
            {
                SigCodeTemplate codeNodeTemplate = new SigCodeTemplate();
                codeNodeTemplate.Code = "Detail";
                codeNodeTemplate.Libelle = "Detail";
                codeTemplates.Add(codeNodeTemplate);
                dataService.DataContext.SaveChanges();

            }

            if ((from c in codeNodes where c.Code.Equals("Folder") select c).Any() == false)
            {
                SigCodeNode codeNodeFolder = new SigCodeNode();
                codeNodeFolder.Code = "Folder";
                codeNodeFolder.Libelle = "Dossier";
                codeNodes.Add(codeNodeFolder);
                dataService.DataContext.SaveChanges();

            }
            if ((from c in codeNodes where c.Code.Equals("Layer") select c).Any() == false)
            {
                SigCodeNode codeNodeLayer = new SigCodeNode();
                codeNodeLayer.Code = "Layer";
                codeNodeLayer.Libelle = "Couche";
                codeNodes.Add(codeNodeLayer);
                dataService.DataContext.SaveChanges();

            }


            if ((from c in codeLayers where c.Code.Equals ("Google") select c).Any() == false)
            {
                SigCodeLayer codeLayerGoogle = new SigCodeLayer();
                codeLayerGoogle.Code = "Google";
                codeLayerGoogle.Libelle = "Google";
                codeLayers.Add(codeLayerGoogle);
                dataService.DataContext.SaveChanges();

            }
            if ((from c in codeLayers where c.Code.Equals("BingAerial") select c).Any() == false)
            {
                SigCodeLayer codeLayerBingAerial = new SigCodeLayer();
                codeLayerBingAerial.Code = "BingAerial";
                codeLayerBingAerial.Libelle = "BingAerial";
                codeLayers.Add(codeLayerBingAerial);
                dataService.DataContext.SaveChanges();

            }
            this._container.RegisterType<CartoViewModel>(new ContainerControlledLifetimeManager());
            this._container.Resolve<CartoViewModel>();
        }
    }
}
