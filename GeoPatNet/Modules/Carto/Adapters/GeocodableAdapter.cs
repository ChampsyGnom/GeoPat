using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;
using DotSpatial.Topology;
using DotSpatial.Topology.Simplify;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Modules.Carto.Adapters
{
    public class GeocodableAdapter: IGeocodable
    {
        public String DisplayName { get;  set; }
        public EntityTableInfo  TableInfo { get; private set; }
        public PropertyInfo PropertyGeom { get; private set; }
        private GeocodableAdapter(EntityTableInfo tableInfo, PropertyInfo propertyGeom)
        {
            this.TableInfo = tableInfo;
            this.PropertyGeom = propertyGeom;
        }
        public static GeocodableAdapter TryAdpat(EntityTableInfo tableInfo)
        {
            PropertyInfo propertyGeom = tableInfo.EntityType.GetProperty("Geom");
            if (propertyGeom != null)
            {
                return new GeocodableAdapter(tableInfo, propertyGeom);
            }
            else
            { return null; }
            
        }

        internal Geometry GetGeometry(object obj)
        {
           byte[] data =(byte[]) this.PropertyGeom.GetValue(obj);
            if (data != null)
            {
            

                   
                    FeatureSetPack result = new FeatureSetPack();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
                    while(ms.Position < ms.Length)
                    {
                       
                        Shape shape  =  WkbFeatureReader.ReadShape(ms);
                        IGeometry geometry=  shape.ToGeometry();
                        if (geometry is LineString)
                        {
                            LineString lineString = geometry as LineString;
                            List<Coordinate> coordinates = new List<Coordinate>();
                            for (int i = 0; i < lineString.Coordinates.Count; i+=2)
                            {coordinates.Add(lineString.Coordinates[i + 1]);}
                            if (coordinates.Count > 1)
                            {
                                lineString = new LineString(coordinates);
                                return lineString;
                            }
                            else
                            { return null; }

                         
                           
                        }
                        if (geometry is MultiLineString)
                        {
                            /*
                            List<LineString> correctLineStrings = new List<LineString>();
                            MultiLineString multiLineString = geometry as MultiLineString;
                            foreach (LineString lineString in multiLineString.Geometries)
                            {
                                List<Coordinate> coordinates = new List<Coordinate>();
                                for (int i = 0; i < lineString.Coordinates.Count; i += 2)
                                { coordinates.Add(lineString.Coordinates[i + 1]); }
                                if (coordinates.Count > 1)
                                {
                                    LineString corecLlineString = new LineString(coordinates);
                                    correctLineStrings.Add(corecLlineString);
                                }
                                
                            }
                            if (correctLineStrings.Count > 0)
                            {
                                multiLineString = new MultiLineString(correctLineStrings);
                                return multiLineString;
                            }
                            else
                            {
                                return null;
                            }
                             * */
                          
                        }
                       
                    }
                
                
              
            }
             
            return null; 
            
        }
        
    }
}
