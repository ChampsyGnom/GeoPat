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
using DotSpatial.Data;
using Emash.GeoPatNet.Modules.Carto.Adapters;
using DotSpatial.Controls;
using DotSpatial.Projections;
using Emash.GeoPatNet.Modules.Carto.Models;

namespace Emash.GeoPatNet.Modules.Carto.Services
{
    public class CartoService : ICartoService
    {
        
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private Referentiel _referentiel;
       
        public CartoService(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._container = container;           
            this._container.RegisterType<CartoView>();
            this._container.RegisterType<CartoViewModel>(new ContainerControlledLifetimeManager());
            
        
             
           
        }

        public void Initialize()
        {

            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du module cartographie ...");
            IDataService dataService = this._container.Resolve<IDataService>();
            DbSet<SigCodeLayer> codeLayers = dataService.GetDbSet<SigCodeLayer>();
            DbSet<SigCodeNode> codeNodes = dataService.GetDbSet<SigCodeNode>();
            DbSet<SigCodeTemplate> codeTemplates = dataService.GetDbSet<SigCodeTemplate>();
            this.Seed(dataService, codeTemplates, codeNodes, codeLayers);
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement données cartographiques ...");
            _referentiel = new Referentiel();
           
           
        }
        public void ShowCarto()
        {
            this._container.Resolve<CartoViewModel>();
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
            DotSpatial.Controls.Map map = view.cartoControl.mapHost.Child as DotSpatial.Controls.Map;
            CartoViewModel vm = this._container.Resolve<CartoViewModel>();
            vm.Map = map;
            map.FunctionMode = DotSpatial.Controls.FunctionMode.Pan;         
            vm.Map.Projection = KnownCoordinateSystems.Projected.World.WebMercator;
            region.Activate(view);
            view.DataContext = vm;
        }


       
        private void Seed(IDataService dataService, DbSet<SigCodeTemplate> codeTemplates, DbSet<SigCodeNode> codeNodes, DbSet<SigCodeLayer> codeLayers)
        {
            this.CreateCodeTemplateIfNeeded(dataService, codeTemplates, "Detail", "Détail");
            this.CreateCodeNodeIfNeeded(dataService, codeNodes, "Folder", "Dossier");
            this.CreateCodeNodeIfNeeded(dataService, codeNodes, "Layer", "Couche");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "BingRoads");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "BingHybrid");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "BingAerial");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "Osm");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "GoogleMap");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "GoogleSatellite");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "GoogleTerrain");
            this.CreateCodeLayerIfNeeded(dataService, codeLayers, "Geocodage");
        }

       

        private void CreateCodeTemplateIfNeeded(IDataService dataService, DbSet<SigCodeTemplate> codeTemplates, string codeTemplateValue, string codeTemplateDisplayeName)
        {
            if ((from c in codeTemplates where c.Code.Equals(codeTemplateValue) select c).Any() == false)
            {
                SigCodeTemplate codeNodeTemplate = new SigCodeTemplate();
                codeNodeTemplate.Code = codeTemplateValue;
                codeNodeTemplate.Libelle = codeTemplateDisplayeName;
                codeTemplates.Add(codeNodeTemplate);
                dataService.DataContext.SaveChanges();

            }
        }

        private void CreateCodeNodeIfNeeded(IDataService dataService, DbSet<SigCodeNode> codeNodes, string codeNodeValue, string codeNodeDisplayeName)
        {
            if ((from c in codeNodes where c.Code.Equals(codeNodeValue) select c).Any() == false)
            {
                SigCodeNode codeNodeLayer = new SigCodeNode();
                codeNodeLayer.Code = codeNodeValue;
                codeNodeLayer.Libelle = codeNodeDisplayeName;
                codeNodes.Add(codeNodeLayer);
                dataService.DataContext.SaveChanges();
            }
          

        }

        private void CreateCodeLayerIfNeeded(IDataService dataService, DbSet<SigCodeLayer> codeLayers, string codeLayerValue)
        {
            if ((from c in codeLayers where c.Code.Equals(codeLayerValue) select c).Any() == false)
            {
                SigCodeLayer codeLayerGoogle = new SigCodeLayer();
                codeLayerGoogle.Code = codeLayerValue;
                codeLayerGoogle.Libelle = codeLayerValue;
                codeLayers.Add(codeLayerGoogle);
                dataService.DataContext.SaveChanges();
            }
        }



        public FeatureSetPack Geocode(IQueryable queryable)
        {

            return null;
        }


        public FeatureSet CreateReferentielFeatureSet()
        {
            return this._referentiel.CreateFeatureSet();
        }
    }
}
