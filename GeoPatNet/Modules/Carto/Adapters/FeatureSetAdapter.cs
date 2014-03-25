using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.Adapters
{
    public class FeatureSetAdapter : FeatureSetPack
    {
        public Extent Extent { get; private set; }
        public IDataService DataService { get; private set; }
        public EntityTableInfo TableInfo { get; private set; }
        public PropertyInfo PropertyGeom { get; private set; }
        public PropertyInfo PropertyLocRef { get; private set; }
        public PropertyInfo PropertyLocDeb { get; private set; }
        public PropertyInfo PropertyLocFin { get; private set; }
        public DbSet DbSet { get; private set; }


        public FeatureSetAdapter(DbSet dbSet)
        {
            this.DbSet = dbSet;
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            this.TableInfo = this.DataService.GetEntityTableInfo(dbSet.ElementType);
            this.PropertyGeom = dbSet.ElementType.GetProperty("Geom");
            if (this.PropertyGeom == null)
            {
                foreach (EntityColumnInfo columnInfo in TableInfo.ColumnInfos)
                {
                    if (columnInfo.IsLocalisationDeb)
                    {this.PropertyLocDeb = columnInfo.Property;}
                    if (columnInfo.IsLocalisationFin)
                    {this.PropertyLocFin = columnInfo.Property;}
                    if (columnInfo.IsLocalisationReferenceId)
                    {this.PropertyLocRef = columnInfo.Property;}
                }
            }
        }
        public void Load()
        {
            if (this.PropertyGeom != null)
            { this.LoadFeatureFromGeomProperty(this.DbSet, this.PropertyGeom); }
            else if (this.PropertyLocRef != null && this.PropertyLocDeb != null)
            { this.GeocodeFeatureFromReference(this.DbSet, PropertyLocRef, PropertyLocDeb, PropertyLocFin); }
        }

        public static Boolean CanAdapt(DbSet dbSet)
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(dbSet.ElementType);
            PropertyInfo propertyGeom = dbSet.ElementType.GetProperty("Geom");
            if (propertyGeom != null) return true;
            EntityColumnInfo columnInfoLocRef = (from c in tableInfo.ColumnInfos where c.IsLocalisationReferenceId select c).FirstOrDefault();
            EntityColumnInfo columnInfoLocDeb = (from c in tableInfo.ColumnInfos where c.IsLocalisationDeb select c).FirstOrDefault();
            EntityColumnInfo columnInfoLocFin = (from c in tableInfo.ColumnInfos where c.IsLocalisationFin select c).FirstOrDefault();
            if (columnInfoLocRef != null && columnInfoLocDeb != null) return true;
            return false;
        }

        private void GeocodeFeatureFromReference(DbSet dbSet, PropertyInfo columnInfoLocRef, PropertyInfo columnInfoLocDeb, PropertyInfo columnInfoLocFin)
        {
            Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            ICartoService cartoService = ServiceLocator.Current.GetInstance<ICartoService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(dbSet.ElementType);
            this.Lines.DataTable = this.CreateDataTable(dbSet.ElementType);
            this.Points.DataTable = this.CreateDataTable(dbSet.ElementType);
            this.Polygons.DataTable = this.CreateDataTable(dbSet.ElementType);
            foreach (Object obj in dbSet)
            {
                if (columnInfoLocFin == null)
                {
                    Nullable<Int64> valueAbs = (Nullable<Int64>)columnInfoLocDeb.GetValue(obj);
                    String propertyChausseeName = columnInfoLocRef.Name.Substring(0, columnInfoLocRef.Name.Length - 2);
                    PropertyInfo propertyChaussee = obj.GetType().GetProperty(propertyChausseeName);
                    InfChaussee chaussee = (InfChaussee)propertyChaussee.GetValue(obj);
                   /*
                    IFeature reference = (from f in cartoService.ReferenceFeatureSet.Features where f.DataRow["Source"] is InfChaussee && (f.DataRow["Source"] as InfChaussee).Id == chaussee.Id select f).FirstOrDefault();
                    if (valueAbs.HasValue && chaussee != null && reference != null)
                    {

                        if (valueAbs.Value >= chaussee.AbsDeb && valueAbs.Value <= chaussee.AbsFin)
                        {
                            double deltaChaussee = (double)chaussee.AbsFin - (double)chaussee.AbsDeb;
                            double fraction = ((double)valueAbs.Value - (double)chaussee.AbsDeb) / ((double)chaussee.AbsFin - (double)chaussee.AbsDeb);
                            if (fraction < 0) throw new Exception("invalid fraction");
                            if (fraction > 1) throw new Exception("invalid fraction");
                            Geometry geometryChaussee = reference.BasicGeometry as Geometry;
                            if (geometryChaussee is LineString)
                            {
                                LineString lineStringChaussee = (geometryChaussee as LineString);
                                double lineStringChausseeLength = lineStringChaussee.Length;
                                double lengthComputed = 0D;
                                double previousLengthComputed = 0D;
                                double positionLenth = fraction * lineStringChausseeLength;
                                for (int i = 1; i < (lineStringChaussee.Coordinates.Count); i++)
                                {
                                    lengthComputed += lineStringChaussee.Coordinates[i - 1].Distance(lineStringChaussee.Coordinates[i]);
                                    if (lengthComputed > positionLenth && previousLengthComputed < positionLenth)
                                    {
                                        double deltaLengthSegement = lengthComputed - previousLengthComputed;
                                        double offset = positionLenth - previousLengthComputed;
                                        double fractionSegment = offset / deltaLengthSegement;
                                        if (fractionSegment < 0) throw new Exception("invalid fraction");
                                        if (fractionSegment > 1) throw new Exception("invalid fraction");
                                        double deltaX = lineStringChaussee.Coordinates[i].X - lineStringChaussee.Coordinates[i - 1].X;
                                        double deltaY = lineStringChaussee.Coordinates[i].Y - lineStringChaussee.Coordinates[i - 1].Y;
                                        double posX = lineStringChaussee.Coordinates[i - 1].X + (deltaX * fractionSegment);
                                        double posY = lineStringChaussee.Coordinates[i - 1].Y + (deltaY * fractionSegment);
                                        Point point = new Point(posX, posY);

                                        IFeature feature = this.Points.AddFeature(point);
                                       // System.Data.DataRow row = this.Points.DataTable.NewRow();
                                      //  row.BeginEdit();
                                      //  row["Source"] = obj;
                                      //  this.Points.DataTable.Rows.Add(row);
                                     //   feature.DataRow = row;
                                      //  row.EndEdit();
                                       

                                    }
                                    previousLengthComputed = lengthComputed;


                                }


                            }
                            else if (geometryChaussee is MultiLineString)
                            {

                                MultiLineString multiLineStringChaussee = (geometryChaussee as MultiLineString);

                                double lineStringChausseeLength = (from l in multiLineStringChaussee.Geometries select (l as LineString).Length).Sum();
                                double lengthComputed = 0D;
                                double previousLengthComputed = 0D;
                                double positionLenth = fraction * lineStringChausseeLength;
                                foreach (LineString ls in multiLineStringChaussee.Geometries)
                                {
                                    for (int i = 1; i < (ls.Coordinates.Count); i++)
                                    {
                                        lengthComputed += ls.Coordinates[i - 1].Distance(ls.Coordinates[i]);
                                        if (lengthComputed > positionLenth && previousLengthComputed < positionLenth)
                                        {
                                            double deltaLengthSegement = lengthComputed - previousLengthComputed;
                                            double offset = positionLenth - previousLengthComputed;
                                            double fractionSegment = offset / deltaLengthSegement;
                                            if (fractionSegment < 0) throw new Exception("invalid fraction");
                                            if (fractionSegment > 1) throw new Exception("invalid fraction");
                                            double deltaX = ls.Coordinates[i].X - ls.Coordinates[i - 1].X;
                                            double deltaY = ls.Coordinates[i].Y - ls.Coordinates[i - 1].Y;
                                            double posX = ls.Coordinates[i - 1].X + (deltaX * fractionSegment);
                                            double posY = ls.Coordinates[i - 1].Y + (deltaY * fractionSegment);
                                            Point point = new Point(posX, posY);
                                            IFeature feature = this.Points.AddFeature(point);
                                           // System.Data.DataRow row = this.Points.DataTable.NewRow();
                                          //  row.BeginEdit();
                                          //  row["Source"] = obj;
                                          //  this.Points.DataTable.Rows.Add(row);
                                          //  feature.DataRow = row;
                                           // row.EndEdit();
                                       

                                        }
                                        previousLengthComputed = lengthComputed;
                                    }
                                }
                            }
                        }
                    }
                    * */

                }
                else
                {

                }
            }
               
        }
     
        private void LoadFeatureFromGeomProperty(DbSet dbSet, PropertyInfo propertyGeom)
        {
            
            Envelope env = new Envelope();
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(dbSet.ElementType);
            this.Lines.DataTable = this.CreateDataTable(dbSet.ElementType);
            this.Points.DataTable = this.CreateDataTable(dbSet.ElementType);
            this.Polygons.DataTable = this.CreateDataTable(dbSet.ElementType);
            PropertyInfo propertyId = dbSet.ElementType.GetProperty("Id");
            foreach (Object obj in dbSet)
            {
              
                Object data = propertyGeom.GetValue(obj);
                if (data != null)
                {
                    String strData = data.ToString();
                    Geometry geometry = this.CreateGeometryFromWkt(strData);
                    if (geometry != null)
                    {

                        env.ExpandToInclude(geometry.Envelope);
                        if (geometry is LineString || geometry is MultiLineString)
                        {
                            IFeature feature = this.Lines.AddFeature(geometry);
                            System.Data.DataRow row = this.Lines.DataTable.NewRow();
                            row.BeginEdit();
                            row["Id"] = (Int64)propertyId.GetValue(obj);                           
                            this.Lines.DataTable.Rows.Add(row);
                            feature.DataRow = row;
                            row.EndEdit();
                        
                        }
                        else if (geometry is Point)
                        {
                            IFeature feature = this.Points.AddFeature(geometry);
                            System.Data.DataRow row = this.Points.DataTable.NewRow();
                            row.BeginEdit();
                            row["Id"] = (Int64)propertyId.GetValue(obj);           
                            this.Points.DataTable.Rows.Add(row);
                            feature.DataRow = row;
                            row.EndEdit();

                        }
                        else if (geometry is Polygon)
                        {
                            IFeature feature = this.Polygons.AddFeature(geometry);
                            System.Data.DataRow row = this.Polygons.DataTable.NewRow();
                            row.BeginEdit();
                            row["Id"] = (Int64)propertyId.GetValue(obj);           
                            this.Polygons.DataTable.Rows.Add(row);
                            feature.DataRow = row;
                            row.EndEdit();
                        }
                    }
                    
                }
            }
            this.Extent = env.ToExtent();
        }

        private System.Data.DataTable CreateDataTable(Type type)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
       
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            EntityTableInfo tableInfo = dataService.GetEntityTableInfo(type);
            dataTable.TableName = tableInfo.EntityType.Name;
            System.Data.DataColumn column = new System.Data.DataColumn();
            column.DataType = typeof(Int64 );
            column.ColumnName = "Id";
            dataTable.Columns.Add(column);                
            return dataTable;
        }

        private Geometry CreateGeometryFromWkt(string strData)
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
