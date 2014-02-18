using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Data.Implementation
{
    public class DataContext : IDataContext
    {

        public DbSet<InfAccident>  InfAccidents
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfAmenagements
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfPrOlds
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfBifurcations
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfBretelles
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfChaussees
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeTrafics
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfClimats
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeAmenagements
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeBifurcations
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeClimats
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeDecs
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeEclairages
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeGares
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeOccupants
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeOccupations
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodePtSings
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodePosits
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeSecurites
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeSensibles
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeTaluss
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeTpcs
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeVoies
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfEclairages
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfFamDecs
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfGares
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfLiaisons
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfOccupations
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfPaveVoies
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfPks
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfPtSings
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfRepartitionTrafics
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfReperes
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfSectionTrafics
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfSecurites
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfSensibles
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfTaluss
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfTpcs
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfTrDecs
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfCodeLiaisons
        {
            get;
            set;
        }


    }
}

