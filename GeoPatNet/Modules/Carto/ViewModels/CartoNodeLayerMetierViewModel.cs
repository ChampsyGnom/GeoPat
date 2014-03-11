using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Topology;
using DotSpatial.Topology.Simplify;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.Adapters;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public  class CartoNodeLayerMetierViewModel :CartoNodeLayerViewModel 
    {
        public FeatureSet FeatureSetPoint { get; private set; }
        public FeatureSet FeatureSetLine { get; private set; }
        public FeatureSet FeatureSetPolygon { get; private set; }

        public MapPointLayer LayerPoint { get; private set; }
        public MapLineLayer  LayerLine { get; private set; }
        public MapPolygonLayer LayerPolygon { get; private set; }

        public CartoNodeLayerMetierViewModel(SigNode node)
            : base(node)
        { }

        public void Load()
        {
            String entityName =  this.Model.SigLayer.SigCodeLayer.Code.Substring(8);
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(entityName);
            GeocodableAdapter geocodableAdapter = GeocodableAdapter.TryAdpat(tableInfo);
            int featureCount = 0;
            if (geocodableAdapter != null)
            {
                
                DbSet set = dataService.GetDbSet(tableInfo.EntityType);
                
                 
                foreach (Object obj in set)
                {
                    Int64 id =(Int64 ) tableInfo.EntityType.GetProperty("Id").GetValue(obj);
                    //Console.WriteLine("Création gémétrie " + entityName + " id " + id);
                    Geometry geometry = geocodableAdapter.GetGeometry(obj);
                    if (geometry != null)
                    {

                       // Feature feature = new Feature();
                       // feature.BasicGeometry = geometry;
                        if (geometry is LineString || geometry is MultiLineString)
                        {
                            
                            this.FeatureSetLine.AddFeature(geometry);
                            featureCount++;
                        }
                        else if (geometry is Point  )
                        {
                            this.FeatureSetPoint.AddFeature(geometry);
                            featureCount++;
                        }
                        else if (geometry is Polygon)
                        {
                            this.FeatureSetPolygon.AddFeature(geometry);
                            featureCount++;
                        }

                    }
                    
                }
            }
            Console.WriteLine("oki : " + featureCount);
            this.Map.ViewExtents = this.LayerLine.Extent;
        }

        public override void CreateLayer(DotSpatial.Controls.Map map)
        {
            this.Map = map;
            String entityTypeName = this.Model.SigLayer.SigCodeLayer.Code.Substring(8);
            EntityTableInfo tableInfo = ServiceLocator.Current.GetInstance<IDataService>().GetEntityTableInfo(entityTypeName);

            this.FeatureSetPoint =  new FeatureSet(FeatureType.Point);
            this.FeatureSetLine = new FeatureSet(FeatureType.Line);
            this.FeatureSetPolygon = new FeatureSet(FeatureType.Polygon);

            this.LayerPoint = new MapPointLayer(this.FeatureSetPoint);
            this.LayerLine = new MapLineLayer(this.FeatureSetLine);
            this.LayerPolygon = new MapPolygonLayer(this.FeatureSetPolygon);

            this.LayerPoint.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            this.LayerLine.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            this.LayerPolygon.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;

            this.Layers.Add(LayerPoint);
            this.Map.Layers.Add(LayerPoint);

            this.Layers.Add(LayerLine);
            this.Map.Layers.Add(LayerLine);

            this.Layers.Add(LayerPolygon);
            this.Map.Layers.Add(LayerPolygon);

            this.Load();
        }
    }
}
