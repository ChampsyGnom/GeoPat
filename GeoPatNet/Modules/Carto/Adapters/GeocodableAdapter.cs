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
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.Adapters
{
    public class GeocodableAdapter: IGeocodable
    {
        public EntityColumnInfo ColumnInfoLocRef { get; private set; }
        public EntityColumnInfo ColumnInfoLocDeb { get; private set; }
        public EntityColumnInfo ColumnInfoLocFin { get; private set; }

        public String DisplayName { get;  set; }
        public EntityTableInfo  TableInfo { get; private set; }
        public PropertyInfo PropertyGeom { get; private set; }
        private GeocodableAdapter(EntityTableInfo tableInfo, PropertyInfo propertyGeom)
        {
            this.TableInfo = tableInfo;
            this.PropertyGeom = propertyGeom;
        }

        public GeocodableAdapter(EntityTableInfo tableInfo, EntityColumnInfo columnInfoLocRef, EntityColumnInfo columnInfoLocDeb, EntityColumnInfo columnInfoLocFin)
        {
            // TODO: Complete member initialization
            this.TableInfo = tableInfo;
            this.ColumnInfoLocRef = columnInfoLocRef;
            this.ColumnInfoLocDeb = columnInfoLocDeb;
            this.ColumnInfoLocFin = columnInfoLocFin;
        }
        public static GeocodableAdapter TryAdpat(EntityTableInfo tableInfo)
        {
            PropertyInfo propertyGeom = tableInfo.EntityType.GetProperty("Geom");
            EntityColumnInfo columnInfoLocRef = (from c in tableInfo.ColumnInfos where c.IsLocalisationReferenceId  select c).FirstOrDefault();
            EntityColumnInfo columnInfoLocDeb = (from c in tableInfo.ColumnInfos where c.IsLocalisationDeb select c).FirstOrDefault();
            EntityColumnInfo columnInfoLocFin = (from c in tableInfo.ColumnInfos where c.IsLocalisationFin select c).FirstOrDefault();

            if (propertyGeom != null)
            {
                return new GeocodableAdapter(tableInfo, propertyGeom);
            }
            else if (columnInfoLocRef != null && columnInfoLocDeb != null)
            {
                return new GeocodableAdapter(tableInfo, columnInfoLocRef, columnInfoLocDeb, columnInfoLocFin);
            }
            else
            {
                return null;
            }
            
        }

        internal Geometry GetGeometry(object obj)
        {
            if (ColumnInfoLocRef != null && ColumnInfoLocDeb != null)
            {
                if (ColumnInfoLocFin == null)
                {
                    Nullable<Int64> valueAbs =( Nullable<Int64>) ColumnInfoLocDeb.Property.GetValue(obj);
                    String propertyChausseeName = ColumnInfoLocRef.PropertyName.Substring(0, ColumnInfoLocRef.PropertyName.Length - 2);
                    PropertyInfo propertyChaussee = obj.GetType ().GetProperty (propertyChausseeName);
                    InfChaussee chaussee = (InfChaussee) propertyChaussee.GetValue(obj);
                    if (valueAbs.HasValue && chaussee != null)
                    {

                        Console.WriteLine("abs " + valueAbs.Value + " chaussee" + chaussee.GetType());
                    }
                    
                }
                else
                { 
                    
                }
            }
            else if (PropertyGeom != null)
            {
                Object data = this.PropertyGeom.GetValue(obj);
                if (data != null)
                {
                    String strData = data.ToString();
                    if (strData.StartsWith("LINESTRING"))
                    {
                        strData = strData.Substring(10);
                        strData = strData.TrimStart().TrimEnd();
                        if (strData.StartsWith("("))
                        { strData = strData.Substring(1); }
                        if (strData.EndsWith(")"))
                        { strData = strData.Substring(0, strData.Length - 1); }
                        strData = strData.TrimStart().TrimEnd();
                        String[] items = strData.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        List<Coordinate> coordinates = new List<Coordinate>();
                        foreach (String item in items)
                        {
                            String[] strCoord = item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            double x = 0;
                            double y = 0;
                            if (double.TryParse(strCoord[0], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out x) &&
                                double.TryParse(strCoord[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out y))
                            {
                                Coordinate coordinate = new Coordinate(x, y);
                                coordinates.Add(coordinate);
                            }
                        }
                        LineString lineString = new LineString(coordinates);
                        return lineString;
                    }
                    else if (strData.StartsWith("MULTILINESTRING"))
                    {
                        strData = strData.Substring(15);
                        strData = strData.TrimStart().TrimEnd();
                        if (strData.StartsWith("("))
                        { strData = strData.Substring(1); }
                        if (strData.EndsWith(")"))
                        { strData = strData.Substring(0, strData.Length - 1); }
                        strData = strData.TrimStart().TrimEnd();

                        bool parse = true;
                        List<LineString> lineStrings = new List<LineString>();
                        while (parse)
                        {
                            int indexStart = strData.IndexOf("(") + 1;
                            int indexEnd = strData.IndexOf(")");
                            if (indexStart != -1 && indexEnd != -1 && indexEnd > indexStart)
                            {
                                String strLine = strData.Substring(indexStart, indexEnd - indexStart);

                                strLine = strLine.TrimStart().TrimEnd();
                                String[] items = strLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                List<Coordinate> coordinates = new List<Coordinate>();
                                foreach (String item in items)
                                {
                                    String[] strCoord = item.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                    double x = 0;
                                    double y = 0;
                                    if (double.TryParse(strCoord[0], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out x) &&
                                        double.TryParse(strCoord[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out y))
                                    {
                                        Coordinate coordinate = new Coordinate(x, y);
                                        coordinates.Add(coordinate);
                                    }
                                }
                                LineString lineString = new LineString(coordinates);
                                lineStrings.Add(lineString);



                                strData = strData.Substring(0, indexEnd);


                            }
                            else parse = false;


                        }
                        MultiLineString multiLineString = new MultiLineString(lineStrings);
                        return multiLineString;

                    }



                }
            }
           
             
            return null; 
            
        }
        
    }
}
