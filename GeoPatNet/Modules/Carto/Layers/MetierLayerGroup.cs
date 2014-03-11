using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.Adapters;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.Layers
{
    public class MetierLayerGroup : LayerGroup
    {

        private string entityName;

        public IFeatureSet FeatureSetPoint { get; private set; }
        public IFeatureSet FeatureSetLine { get; private set; }
        public IFeatureSet FeatureSetPolygon { get; private set; }
        public MapPointLayer LayerPoint { get; private set; }
        public MapLineLayer LayerLine { get; private set; }
        public MapPolygonLayer LayerPolygon { get; private set; }
        public IDataService DataService { get; private set; }
        public EntityTableInfo TableInfo { get; private set; }
        public FeatureSetAdapter FeatureSetPack { get; private set; }
        public DbSet DbSet { get; private set; }

        public MetierLayerGroup(Type entityType)
        {
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.TableInfo = this.DataService.GetEntityTableInfo(entityType);
            this.DbSet = this.DataService.GetDbSet (entityType);
            this.FeatureSetPack = new FeatureSetAdapter(this.DbSet);
            this.FeatureSetLine = this.FeatureSetPack.Lines;
            this.FeatureSetPoint = this.FeatureSetPack.Points ;
            this.FeatureSetPolygon = this.FeatureSetPack.Polygons;
            this.LayerPoint = new MapPointLayer(this.FeatureSetPoint);
            this.LayerLine = new MapLineLayer(this.FeatureSetLine);
            this.LayerPolygon = new MapPolygonLayer(this.FeatureSetPolygon);
            
            LineSymbolizer lineSymbolizer = new LineSymbolizer();
            lineSymbolizer.SetFillColor(System.Drawing.Color.LightGray);
            lineSymbolizer.SetOutline(System.Drawing.Color.DarkGray, 1D);
            /*
            LineScheme myScheme = new LineScheme();
            MetierCategory category = new MetierCategory();
            category.Symbolizer = lineSymbolizer;
            category.FilterExpression = "[Analysis]=-1";
            myScheme.Categories.Add(category);
            this.LayerLine.Symbology = myScheme;
            */
            this.LayerLine.Symbolizer = lineSymbolizer;
            this.Add(this.LayerPoint);
            this.Add(this.LayerLine);
            this.Add(this.LayerPolygon);
            

        }
        public override void Load()
        {
            base.Load();
            this.FeatureSetPack.Load();
            this.FeatureSetLine = this.FeatureSetPack.Lines;
            this.FeatureSetPoint = this.FeatureSetPack.Points;
            this.FeatureSetPolygon = this.FeatureSetPack.Polygons;
            this.LayerPoint = new MapPointLayer(this.FeatureSetPoint);
            this.LayerLine = new MapLineLayer(this.FeatureSetLine);
            this.LayerPolygon = new MapPolygonLayer(this.FeatureSetPolygon);
        }
       
        public MetierLayerGroup(string entityName) :this( ServiceLocator.Current.GetInstance<IDataService>().GetEntityTableInfo(entityName).EntityType)
        {
         
        }
    }
}
