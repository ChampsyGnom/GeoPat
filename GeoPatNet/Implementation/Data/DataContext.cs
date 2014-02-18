using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Implementation
{
    public class DataContext : IDataContext
    {
	    public DataContext(DbConnection connection)
            : base(connection)
        {
        
        }

        public DbSet<InfAccident>  InfAccidents
        {
            get;
            set;
        }
        public DbSet<InfAmenagement>  InfAmenagements
        {
            get;
            set;
        }
        public DbSet<InfPrOld>  InfPrOlds
        {
            get;
            set;
        }
        public DbSet<InfBifurcation>  InfBifurcations
        {
            get;
            set;
        }
        public DbSet<InfBretelle>  InfBretelles
        {
            get;
            set;
        }
        public DbSet<InfChaussee>  InfChaussees
        {
            get;
            set;
        }
        public DbSet<InfCodeTrafic>  InfCodeTrafics
        {
            get;
            set;
        }
        public DbSet<InfClimat>  InfClimats
        {
            get;
            set;
        }
        public DbSet<InfCodeAmenagement>  InfCodeAmenagements
        {
            get;
            set;
        }
        public DbSet<InfCodeBifurcation>  InfCodeBifurcations
        {
            get;
            set;
        }
        public DbSet<InfCodeClimat>  InfCodeClimats
        {
            get;
            set;
        }
        public DbSet<InfCodeDec>  InfCodeDecs
        {
            get;
            set;
        }
        public DbSet<InfCodeEclairage>  InfCodeEclairages
        {
            get;
            set;
        }
        public DbSet<InfCodeGare>  InfCodeGares
        {
            get;
            set;
        }
        public DbSet<InfCodeOccupant>  InfCodeOccupants
        {
            get;
            set;
        }
        public DbSet<InfCodeOccupation>  InfCodeOccupations
        {
            get;
            set;
        }
        public DbSet<InfCodePtSing>  InfCodePtSings
        {
            get;
            set;
        }
        public DbSet<InfCodePosit>  InfCodePosits
        {
            get;
            set;
        }
        public DbSet<InfCodeSecurite>  InfCodeSecurites
        {
            get;
            set;
        }
        public DbSet<InfCodeSensible>  InfCodeSensibles
        {
            get;
            set;
        }
        public DbSet<InfCodeTalus>  InfCodeTaluss
        {
            get;
            set;
        }
        public DbSet<InfCodeTpc>  InfCodeTpcs
        {
            get;
            set;
        }
        public DbSet<InfCodeVoie>  InfCodeVoies
        {
            get;
            set;
        }
        public DbSet<InfEclairage>  InfEclairages
        {
            get;
            set;
        }
        public DbSet<InfFamDec>  InfFamDecs
        {
            get;
            set;
        }
        public DbSet<InfGare>  InfGares
        {
            get;
            set;
        }
        public DbSet<InfLiaison>  InfLiaisons
        {
            get;
            set;
        }
        public DbSet<InfOccupation>  InfOccupations
        {
            get;
            set;
        }
        public DbSet<InfPaveVoie>  InfPaveVoies
        {
            get;
            set;
        }
        public DbSet<InfPk>  InfPks
        {
            get;
            set;
        }
        public DbSet<InfPtSing>  InfPtSings
        {
            get;
            set;
        }
        public DbSet<InfRepartitionTrafic>  InfRepartitionTrafics
        {
            get;
            set;
        }
        public DbSet<InfRepere>  InfReperes
        {
            get;
            set;
        }
        public DbSet<InfSectionTrafic>  InfSectionTrafics
        {
            get;
            set;
        }
        public DbSet<InfSecurite>  InfSecurites
        {
            get;
            set;
        }
        public DbSet<InfSensible>  InfSensibles
        {
            get;
            set;
        }
        public DbSet<InfTalus>  InfTaluss
        {
            get;
            set;
        }
        public DbSet<InfTpc>  InfTpcs
        {
            get;
            set;
        }
        public DbSet<InfTrDec>  InfTrDecs
        {
            get;
            set;
        }
        public DbSet<InfCodeLiaison>  InfCodeLiaisons
        {
            get;
            set;
        }


    }
}

