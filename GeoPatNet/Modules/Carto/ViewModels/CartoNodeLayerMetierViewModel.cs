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
using DotSpatial.Symbology;
using DotSpatial.Topology;
using DotSpatial.Topology.Simplify;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.Adapters;
using Emash.GeoPatNet.Modules.Carto.Layers;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public  class CartoNodeLayerMetierViewModel :CartoNodeLayerViewModel 
    {
        public IFeatureSet FeatureSetPoint { get; private set; }
        public IFeatureSet FeatureSetLine { get; private set; }
        public IFeatureSet FeatureSetPolygon { get; private set; }

        public MapPointLayer LayerPoint { get; private set; }
        public MapLineLayer  LayerLine { get; private set; }
        public MapPolygonLayer LayerPolygon { get; private set; }

        public CartoNodeLayerMetierViewModel(SigNode node)
            : base(node)
        {
            String entityName = this.Model.SigLayer.SigCodeLayer.Code.Substring(8);
            this.LayerGroup  = new MetierLayerGroup(entityName);
        }
        /*
        public void Load()
        {
            String entityName =  this.Model.SigLayer.SigCodeLayer.Code.Substring(8);
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(entityName);
            FeatureSetAdapter adapter = new FeatureSetAdapter(dataService.GetDbSet(tableInfo.EntityType));
            this.FeatureSetLine = adapter.Lines;
            this.FeatureSetPoint = adapter.Points;
            this.FeatureSetPolygon = adapter.Polygons;
            Console.WriteLine("oki : " + FeatureSetLine.Features.Count );
            this.LayerPoint = new MapPointLayer(this.FeatureSetPoint);
            this.LayerLine = new MapLineLayer(this.FeatureSetLine);
            this.LayerPolygon = new MapPolygonLayer(this.FeatureSetPolygon);


            LineSymbolizer lineSymbolizer = new LineSymbolizer();
            lineSymbolizer.SetFillColor (System.Drawing.Color.LightGray) ;
            lineSymbolizer.SetOutline(System.Drawing.Color.DarkGray, 1D);      
            LineScheme myScheme = new LineScheme();
            MetierCategory category = new MetierCategory();
            category.Symbolizer = lineSymbolizer;
            category.FilterExpression = "[Analysis]=-1";
            myScheme.Categories.Add(category);
            this.LayerLine.Symbology = myScheme;

            this.LayerPoint.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            this.LayerLine.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            this.LayerPolygon.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            if (this.LayerLine.FeatureSet.Features.Count > 0)
            { this.Map.ViewExtents = this.LayerLine.Extent; }
           
        }

      

        public override void CreateLayer(DotSpatial.Controls.Map map)
        {
            this.Map = map;
            String entityTypeName = this.Model.SigLayer.SigCodeLayer.Code.Substring(8);
            EntityTableInfo tableInfo = ServiceLocator.Current.GetInstance<IDataService>().GetEntityTableInfo(entityTypeName);
            this.Load();
            this.Layers.Add(LayerPoint);
            this.Map.Layers.Add(LayerPoint);
            this.Layers.Add(LayerLine);
            this.Map.Layers.Add(LayerLine);
            this.Layers.Add(LayerPolygon);
            this.Map.Layers.Add(LayerPolygon);
        }
        */
        public override LayerGroup LayerGroup
        {
            get;
            protected set;
        }
    }
}
