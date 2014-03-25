using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Topology;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Carto.Utils;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Modules.Carto.Models
{
    public class Referentiel
    {

        public List<ReferentielMultiLineString> MultiLineStrings { get; private set; }
        public IDataService DataService { get; private set; }

        public Referentiel()
        {
            this.MultiLineStrings = new List<ReferentielMultiLineString>();
            this.DataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<InfChaussee> setChaussee = this.DataService.GetDbSet<InfChaussee>();
            foreach (InfChaussee chaussee in setChaussee)
            {
                if (!String.IsNullOrEmpty(chaussee.Geom))
                {
                    ReferentielMultiLineString mls = new ReferentielMultiLineString(chaussee);
                    this.MultiLineStrings.Add(mls);
                }
            }
        }

        internal FeatureSet CreateFeatureSet()
        {
            FeatureSet featureSet = new FeatureSet(FeatureType.Line);
            featureSet.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            foreach (ReferentielMultiLineString mls in this.MultiLineStrings)
            {
                List<LineString> lineStrings = new List<LineString>();
                foreach (ReferentielLineString ls in mls.LineStrings)
                {
                    List<Coordinate> coordinates = new List<Coordinate>();
                    for (int i = 0; i < (ls.Segements.Count - 1); i++)
                    {
                        coordinates.Add(ls.Segements[i].CoordDeb);
                    }
                    coordinates.Add(ls.Segements.Last().CoordDeb);
                    coordinates.Add(ls.Segements.Last().CoordFin);
                    LineString fsLs = new LineString(coordinates);
                    lineStrings.Add(fsLs);
                }
                MultiLineString fsMls = new MultiLineString(lineStrings);
                featureSet.AddFeature(fsMls);
            }            
            return featureSet;
        }
    }

    public class ReferentielMultiLineString
    {
        public InfChaussee Chaussee { get;private  set; }
        public List<ReferentielLineString> LineStrings { get; set; }
        private double AbsDeb { get; set; }
        private double AbsFin { get; set; }
        public ReferentielMultiLineString(InfChaussee chaussee)
        {
            this.Chaussee = chaussee;
            this.AbsDeb = chaussee.AbsDeb;
            this.AbsFin = chaussee.AbsFin;
            this.LineStrings = new List<ReferentielLineString>();
            Geometry geometry =  WktHelper.CreateGeometryFromWkt(this.Chaussee.Geom);
            if (geometry is MultiLineString)
            {
                MultiLineString mls = (geometry as MultiLineString);
                double totalLength = 0;
                double absCurrent = this.AbsDeb;
                foreach (LineString ls in mls.Geometries)
                {totalLength += ls.Length;}
                double coeff = (this.AbsFin - this.AbsDeb) / totalLength;

                foreach (LineString ls in mls.Geometries)
                {
                    double lengthInAbs = ls.Length* coeff;
                    ReferentielLineString refLineString = new ReferentielLineString(chaussee, absCurrent, (absCurrent+lengthInAbs), ls);
                    this.LineStrings.Add(refLineString);
                    absCurrent += lengthInAbs;
                }
                this.LineStrings.First().Segements.First().AbsDeb = this.AbsDeb;               
                this.LineStrings.Last().Segements.Last().AbsFin = this.AbsFin;
            }
            else if (geometry is LineString)
            {
                LineString ls = (geometry as LineString);
                ReferentielLineString refLineString = new ReferentielLineString(chaussee,chaussee.AbsDeb, chaussee.AbsFin, ls);
                this.LineStrings.Add(refLineString);
            }
        }
    }

    public class ReferentielLineString
    {
        private InfChaussee Chaussee { get; set; }
        public double AbsDeb { get; private set; }
        public double AbsFin { get; private set; }
        public List<ReferentielSegment> Segements { get; set; }

        public ReferentielLineString(InfChaussee chaussee, double absDeb, double absFin, LineString ls)
        {
            // TODO: Complete member initialization
            this.Segements = new List<ReferentielSegment>();
            this.Chaussee = chaussee;
            this.AbsDeb = absDeb;
            this.AbsFin = absFin;
            double deltaAbs = this.AbsFin - this.AbsDeb;
            double coeff = deltaAbs / ls.Length;
            double absCurrent = this.AbsDeb;
            for (int i = 0; i < ls.Coordinates.Count - 1; i++)
            {
                Coordinate coordDeb = ls.Coordinates[i];
                Coordinate coordFin = ls.Coordinates[i+1];
                double segmentLength = new LineString(new Coordinate[] { coordDeb,coordFin  }).Length;
                if (segmentLength > 0)
                {
                    double lengthInAbs = segmentLength * coeff;
                    ReferentielSegment segment = new ReferentielSegment(coordDeb, coordFin, absCurrent, absCurrent + lengthInAbs);
                    this.Segements.Add(segment);
                    absCurrent += lengthInAbs;
                }               
            }
            this.Segements.First().AbsDeb = absDeb;
         
            this.Segements.Last().AbsFin = absFin;
            
        }
       
    }

    public class ReferentielSegment
    {
        public Coordinate CoordDeb { get; set; }
        public Coordinate CoordFin { get; set; }
        public double AbsDeb { get; set; }
        public double AbsFin { get; set; }

        public ReferentielSegment(Coordinate coordDeb, Coordinate coordFin, double absDeb, double absFin)
        {
            // TODO: Complete member initialization
            this.CoordDeb = coordDeb;
            this.CoordFin = coordFin;
            this.AbsDeb = absDeb;
            this.AbsFin = absFin;
        }
        
    }
}
