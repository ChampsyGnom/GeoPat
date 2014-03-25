using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Modules.Carto.Utils;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;


namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateNodeLayerViewModel : TemplateNodeViewModel
    {
        public Envelope Envelope { get; private set; }
        public List<IMapLayer> Layers { get; private set; }
        public TemplateNodeLayerViewModel(SigNode model)
        {
            // TODO: Complete member initialization
            this.Model = model;
            this.DisplayName = model.Libelle;
            this.Layers = new List<IMapLayer>();
        }

        internal void CreateLayers()
        {
            Envelope env = new Envelope();
            if (this.Model.SigLayer != null)
            {
                if (this.Model.SigLayer.SigCodeLayer.Code == "Geocodage")
                {
                    FeatureSet featureSetPoint = new FeatureSet(FeatureType.Point);
                    featureSetPoint.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
                    PointSymbolizer featureSetPointSymbolizer = new PointSymbolizer(System.Drawing.Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 10);
                    FeatureSet featureSetLine = new FeatureSet(FeatureType.Line);
                    featureSetLine.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
                    IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                    ICartoService cartoService = ServiceLocator.Current.GetInstance<ICartoService>();
                    EntityTableInfo tableInfo = dataService.GetEntityTableInfo(this.Model.SigLayer.EntityName);
                    IQueryable queryable = dataService.GetDbSet(tableInfo.EntityType).AsQueryable();
                    EntityColumnInfo columnGeom = (from c in tableInfo.ColumnInfos where c.IsLocalisationReferenceGeom  select c).FirstOrDefault();
                    EntityColumnInfo columnRef = (from c in tableInfo.ColumnInfos where c.IsLocalisationReferenceId select c).FirstOrDefault();
                    EntityColumnInfo columnDeb = (from c in tableInfo.ColumnInfos where c.IsLocalisationDeb select c).FirstOrDefault();
                    EntityColumnInfo columnFin = (from c in tableInfo.ColumnInfos where c.IsLocalisationFin select c).FirstOrDefault();
                    
                    foreach (Object item in queryable)
                    {
                        Geometry geometry = null;
                        if (columnGeom != null)
                        {
                            Object dataGeom = columnGeom.Property.GetValue(item);
                            if (dataGeom != null)
                            {geometry = WktHelper.CreateGeometryFromWkt(dataGeom.ToString());}
                        }
                        if (geometry == null && columnRef != null && columnDeb != null)
                        {
                            Object objRef = columnRef.Property.GetValue(item);
                            Object objDeb = columnDeb.Property.GetValue(item);
                                
                            if (columnFin == null)
                            {
                               if (objRef != null && objRef is Int64 && objDeb != null && objDeb is Int64)
                                {

                                    geometry = cartoService.Geocode((Int64)objRef, (Int64)objDeb );
                                }
                            }
                            else
                            {
                                Object objFin = columnFin.Property.GetValue(item);
                                if (objRef != null && objRef is Int64 && objDeb != null && objDeb is Int64)
                                {
                                    if (objFin != null && objFin is Int64)
                                    { geometry = cartoService.Geocode((Int64)objRef, (Int64)objDeb, (Int64)objFin); }
                                    else
                                    { geometry = cartoService.Geocode((Int64)objRef, (Int64)objDeb); }
                                }
                            }
                        }

                        if (geometry != null)
                        {
                            if (geometry is Point)
                            {
                                featureSetPoint.AddFeature(geometry);
                                env.ExpandToInclude(geometry.Envelope);
                            }
                            else if (geometry is LineString)
                            { 
                                featureSetLine.AddFeature(geometry);
                                env.ExpandToInclude(geometry.Envelope);
                            }
                            else if (geometry is MultiLineString )
                            {
                                featureSetLine.AddFeature(geometry);
                                env.ExpandToInclude(geometry.Envelope);
                            }
                        }


                    }
                    this.Layers.Add(new MapLineLayer(featureSetLine));
                    this.Layers.Add(new MapPointLayer(featureSetPoint));
                }
                
            }
            
            this.Envelope = env;
        }
    }
}
