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
           object data = this.PropertyGeom.GetValue(obj);
            if (data != null)
            {
                String strData = data.ToString();
                if (!String.IsNullOrEmpty(strData))
                {
                   // Console.WriteLine("Load geom taille chaine HEX : " + strData.Length);

                    Byte[] bytes = StringToByteArray(strData);
                    MemoryStream stream = new MemoryStream (bytes);
                    if (bytes.Length > 0)
                    {
                        Shape shape =   WkbFeatureReader.ReadShape (stream);
                        Geometry resultGeometry = shape.ToGeometry() as Geometry;
                        stream.Close();
                        stream.Dispose();
                        if (resultGeometry is LineString)
                        {
                            LineString ls = (resultGeometry as LineString);
                            IList<Coordinate> coordsSimple =   DouglasPeuckerLineSimplifier.Simplify(ls.Coordinates, 100D);
                            resultGeometry = new LineString(coordsSimple);
                           
                        }
                        if (resultGeometry is MultiLineString)
                        {
                            List<LineString> simpleLineStrings = new List<LineString>();
                            MultiLineString mls = (resultGeometry as MultiLineString);
                            foreach (LineString ls in mls.Geometries)
                            {
                                IList<Coordinate> coordsSimple = DouglasPeuckerLineSimplifier.Simplify(ls.Coordinates, 100D);
                                simpleLineStrings.Add (new LineString (coordsSimple));
                            }
                            resultGeometry = new MultiLineString (simpleLineStrings);
                        }
                        return resultGeometry;
                           
                    }
                    stream.Close();
                    stream.Dispose();
                }
                strData = null;
            }
             
            return null; 
            
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
