using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Topology;

namespace Emash.GeoPatNet.Modules.Carto.Utils
{
    public static   class WktHelper
    {
        public static Geometry CreateGeometryFromWkt(string strData)
        {
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
            return null;
        }
    }
}
