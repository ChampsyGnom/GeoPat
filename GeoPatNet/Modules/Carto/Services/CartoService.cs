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
using DotSpatial.Topology;

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



        public ReferentielMultiLineString GetChausseeMultiLineString(long chausseeId)
        {
            return (from c in _referentiel.MultiLineStrings where c.Chaussee.Id == chausseeId select c).FirstOrDefault();
        }

        public DotSpatial.Topology.Geometry Geocode(long chausseeId, long absDeb)
        {
            ReferentielMultiLineString mls = this.GetChausseeMultiLineString (chausseeId );
            if (mls != null)
            {
                ReferentielLineString ls = (from l in mls.LineStrings where absDeb >= l.AbsDeb && absDeb < l.AbsFin select l).FirstOrDefault();
                if (ls != null)
                {
                    ReferentielSegment seg = (from s in ls.Segements where absDeb >= s.AbsDeb && absDeb < s.AbsFin select s).FirstOrDefault();
                    if (seg != null)
                    {
                        double fraction = (absDeb - seg.AbsDeb) / (seg.AbsFin - seg.AbsDeb);
                        double x = seg.CoordDeb.X + ((seg.CoordFin.X - seg.CoordDeb.X) * fraction);
                        double y = seg.CoordDeb.Y + ((seg.CoordFin.Y - seg.CoordDeb.Y) * fraction);
                        Point pt = new Point(x, y);
                        return pt;
                        
                    }
                }
            }
            return null;
            
        }

        public DotSpatial.Topology.Geometry Geocode(long chausseeId, long absDeb, long absFin)
        {
            ReferentielMultiLineString mls = this.GetChausseeMultiLineString(chausseeId);
            if (mls != null)
            {
                ReferentielLineString lsDeb = (from l in mls.LineStrings where absDeb >= l.AbsDeb && absDeb < l.AbsFin select l).FirstOrDefault();
                ReferentielLineString lsFin = (from l in mls.LineStrings where absFin >= l.AbsDeb && absFin < l.AbsFin select l).FirstOrDefault();
                if (lsDeb != null && lsFin != null)
                {
                    if (mls.LineStrings.IndexOf(lsDeb) == mls.LineStrings.IndexOf(lsFin))
                    {
                        ReferentielSegment segDeb = (from s in lsDeb.Segements where absDeb >= s.AbsDeb && absDeb < s.AbsFin select s).FirstOrDefault();
                        ReferentielSegment segFin = (from s in lsDeb.Segements where absFin >= s.AbsDeb && absFin < s.AbsFin select s).FirstOrDefault();
                        if (segDeb != null && segFin != null)
                        {
                            if (lsDeb.Segements.IndexOf(segDeb) == lsDeb.Segements.IndexOf(segFin))
                            {
                                // sur le meme segment de la linestring
                                List<Coordinate> coordinates = new List<Coordinate>();
                                double fractionSegDeb = (absDeb - segDeb.AbsDeb) / (segDeb.AbsFin - segDeb.AbsDeb);
                                double fractionSegFin = (absFin - segFin.AbsDeb) / (segFin.AbsFin - segFin.AbsDeb);
                                double xDeb = segDeb.CoordDeb.X + ((segDeb.CoordFin.X - segDeb.CoordDeb.X) * fractionSegDeb);
                                double yDeb = segDeb.CoordDeb.Y + ((segDeb.CoordFin.Y - segDeb.CoordDeb.Y) * fractionSegDeb);
                                double xFin = segFin.CoordDeb.X + ((segFin.CoordFin.X - segFin.CoordDeb.X) * fractionSegFin);
                                double yFin = segFin.CoordDeb.Y + ((segFin.CoordFin.Y - segFin.CoordDeb.Y) * fractionSegFin);
                                coordinates.Add(new Coordinate(xDeb, yDeb));
                                coordinates.Add(new Coordinate(xFin, yFin));
                                LineString ls = new LineString(coordinates);
                                return ls;
                                //Console.WriteLine("sur le meme segment de la linestring");
                            }
                            else
                            {
                                List<Coordinate> coordinates = new List<Coordinate>();
                                double fractionSegDeb = (absDeb - segDeb.AbsDeb) / (segDeb.AbsFin - segDeb.AbsDeb);
                                double fractionSegFin = (absFin - segFin.AbsDeb) / (segFin.AbsFin - segFin.AbsDeb);
                                double xDeb = segDeb.CoordDeb.X + ((segDeb.CoordFin.X - segDeb.CoordDeb.X) * fractionSegDeb);
                                double yDeb = segDeb.CoordDeb.Y + ((segDeb.CoordFin.Y - segDeb.CoordDeb.Y) * fractionSegDeb);
                                double xFin = segFin.CoordDeb.X + ((segFin.CoordFin.X - segFin.CoordDeb.X) * fractionSegFin);
                                double yFin = segFin.CoordDeb.Y + ((segFin.CoordFin.Y - segFin.CoordDeb.Y) * fractionSegFin);
                                coordinates.Add(new Coordinate(xDeb, yDeb));
                                int indexSegDeb = lsDeb.Segements.IndexOf(segDeb);
                                int indexSegFin = lsDeb.Segements.IndexOf(segFin);
                                for (int i = indexSegDeb; i < indexSegFin; i++)
                                {
                                    ReferentielSegment s = lsDeb.Segements[i];
                                    coordinates.Add(s.CoordFin);
                                }
                                coordinates.Add(new Coordinate(xFin, yFin));
                                LineString ls = new LineString(coordinates);
                                return ls;
                                // sur plusieur segment de la linestring
                               // Console.WriteLine("sur plusieur segment de la linestring");
                            }
                        }
                       
                    }
                    else
                    { 
                        // sur plusieur lignes de la multilinestring
                        //Console.WriteLine("sur plusieur lignes de la multilinestring");
                    }
                }
                
            }
            return null;
        }
    }
}
