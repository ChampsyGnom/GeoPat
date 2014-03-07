using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;
using DotSpatial.Topology;
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
           object data = this.PropertyGeom.GetValue(obj);
            if (data != null)
            {
                Byte [] bytes = StringToByteArray(data.ToString ());           
 
                FeatureSetPack pk = WkbFeatureReader.GetFeatureSets(bytes);

                // To read a single feature at a time:
                FeatureSetPack result = new FeatureSetPack();
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                while (ms.Position < ms.Length)
                {
                    WkbFeatureReader.ReadFeature(ms, result);
                }

               
                // To add the line, point and polygon shapefiles that are not empty:
                foreach (IFeatureSet set in pk)
                {

                    
                      
                    IFeature feature = set.GetFeature(0);
                    Geometry resultGeometry = feature.BasicGeometry as Geometry;
                    return resultGeometry;
                    
                   
                 
                }
                return null;
            }
            else
            { 
                return null; 
            }
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
