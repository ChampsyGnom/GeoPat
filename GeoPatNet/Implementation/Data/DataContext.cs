using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation
{
    public class DataContext : IDataContext
    {
	    private DbModelBuilder _modelBuilder;
        public override DbModelBuilder ModelBuilder
        {
            get { return _modelBuilder; }
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
	   
        
	    public DataContext(DbConnection connection)
            : base(connection)
        {
        
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
            this._modelBuilder = modelBuilder;
            modelBuilder.Entity<InfAccident>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfAccidents);
            modelBuilder.Entity<InfAccident>().ToTable("INF_ACCIDENT", "INF");
            modelBuilder.Entity<InfAccident>().Property(t => t.Annee) .HasColumnName("INF_ACCIDENT__ANNEE");
            modelBuilder.Entity<InfAccident>().Property(t => t.Annee).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsDeb) .HasColumnName("INF_ACCIDENT__ABS_DEB");
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsFin) .HasColumnName("INF_ACCIDENT__ABS_FIN");
            modelBuilder.Entity<InfAccident>().Property(t => t.Id) .HasColumnName("INF_ACCIDENT__ID");
            modelBuilder.Entity<InfAccident>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfAccident>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.Mois) .HasColumnName("INF_ACCIDENT__MOIS");
            modelBuilder.Entity<InfAccident>().Property(t => t.Mois).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.Nb) .HasColumnName("INF_ACCIDENT__NB");
            modelBuilder.Entity<InfAccident>().Property(t => t.NbMois) .HasColumnName("INF_ACCIDENT__NB_MOIS");
            modelBuilder.Entity<InfAccident>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAccident>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAmenagement>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfAmenagements);
            modelBuilder.Entity<InfAmenagement>().HasRequired<InfCodeAmenagement>(c => c.InfCodeAmenagement).WithMany(t => t.InfAmenagements);
            modelBuilder.Entity<InfAmenagement>().ToTable("INF_AMENAGEMENT", "INF");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Info) .HasColumnName("INF_AMENAGEMENT__INFO");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Cout) .HasColumnName("INF_AMENAGEMENT__COUT");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateDeb) .HasColumnName("INF_AMENAGEMENT__DATE_DEB");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateFin) .HasColumnName("INF_AMENAGEMENT__DATE_FIN");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsDeb) .HasColumnName("INF_AMENAGEMENT__ABS_DEB");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsFin) .HasColumnName("INF_AMENAGEMENT__ABS_FIN");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id) .HasColumnName("INF_AMENAGEMENT__ID");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfCodeAmenagementId) .HasColumnName("INF_CD_AMENAGEMENT__ID");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfCodeAmenagementId).IsRequired();
            modelBuilder.Entity<InfAmenagement>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPrOld>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPrOlds);
            modelBuilder.Entity<InfPrOld>().ToTable("INF_PR_OLD", "INF");
            modelBuilder.Entity<InfPrOld>().Property(t => t.AbsCum) .HasColumnName("INF_PR_OLD__ABS_CUM");
            modelBuilder.Entity<InfPrOld>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Inter) .HasColumnName("INF_PR_OLD__INTER");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id) .HasColumnName("INF_PR_OLD__ID");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfPrOld>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Num) .HasColumnName("INF_PR_OLD__NUM");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfPrOld>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfBifurcation>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfBifurcations);
            modelBuilder.Entity<InfBifurcation>().HasRequired<InfCodeBifurcation>(c => c.InfCodeBifurcation).WithMany(t => t.InfBifurcations);
            modelBuilder.Entity<InfBifurcation>().ToTable("INF_BIFURCATION", "INF");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Info) .HasColumnName("INF_BIFURCATION__INFO");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.DateMs) .HasColumnName("INF_BIFURCATION__DATE_MS");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.AbsDeb) .HasColumnName("INF_BIFURCATION__ABS_DEB");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id) .HasColumnName("INF_BIFURCATION__ID");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfCodeBifurcationId) .HasColumnName("INF_CD_BIFURCATION__ID");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfCodeBifurcationId).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.NumExploit) .HasColumnName("INF_BIFURCATION__NUM_EXPLOIT");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Nom) .HasColumnName("INF_BIFURCATION__NOM");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfBifurcation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfBretelle>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfBretelles);
            modelBuilder.Entity<InfBretelle>().ToTable("INF_BRETELLE", "INF");
            modelBuilder.Entity<InfBretelle>().Property(t => t.AbsDeb) .HasColumnName("INF_BRETELLE__ABS_DEB");
            modelBuilder.Entity<InfBretelle>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.Extremite) .HasColumnName("INF_BRETELLE__EXTREMITE");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Extremite).HasMaxLength(100);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id) .HasColumnName("INF_BRETELLE__ID");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfBretelle>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.Libelle) .HasColumnName("INF_BRETELLE__LIBELLE");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Num) .HasColumnName("INF_BRETELLE__NUM");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Num).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().Property(t => t.NumExploit) .HasColumnName("INF_BRETELLE__NUM_EXPLOIT");
            modelBuilder.Entity<InfBretelle>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Nom) .HasColumnName("INF_BRETELLE__NOM");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Type) .HasColumnName("INF_BRETELLE__TYPE");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Type).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().HasKey(t => t.Id);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfChaussee>().HasRequired<InfLiaison>(c => c.InfLiaison).WithMany(t => t.InfChaussees);
            modelBuilder.Entity<InfChaussee>().ToTable("INF_CHAUSSEE", "INF");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code) .HasColumnName("INF_CHAUSSEE__CODE");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.InfLiaisonId) .HasColumnName("INF_LIAISON__ID");
            modelBuilder.Entity<InfChaussee>().Property(t => t.InfLiaisonId).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.Libelle) .HasColumnName("INF_CHAUSSEE__LIBELLE");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfChaussee>().HasKey(t => t.Id);
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTrafic>().ToTable("INF_CD_TRAFIC", "INF");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code) .HasColumnName("INF_CD_TRAFIC__CODE");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id) .HasColumnName("INF_CD_TRAFIC__ID");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Libelle) .HasColumnName("INF_CD_TRAFIC__LIBELLE");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfClimat>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfClimats);
            modelBuilder.Entity<InfClimat>().HasRequired<InfCodeClimat>(c => c.InfCodeClimat).WithMany(t => t.InfClimats);
            modelBuilder.Entity<InfClimat>().ToTable("INF_CLIMAT", "INF");
            modelBuilder.Entity<InfClimat>().Property(t => t.Info) .HasColumnName("INF_CLIMAT__INFO");
            modelBuilder.Entity<InfClimat>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsDeb) .HasColumnName("INF_CLIMAT__ABS_DEB");
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsFin) .HasColumnName("INF_CLIMAT__ABS_FIN");
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.Id) .HasColumnName("INF_CLIMAT__ID");
            modelBuilder.Entity<InfClimat>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfClimat>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.InfCodeClimatId) .HasColumnName("INF_CD_CLIMAT__ID");
            modelBuilder.Entity<InfClimat>().Property(t => t.InfCodeClimatId).IsRequired();
            modelBuilder.Entity<InfClimat>().HasKey(t => t.Id);
            modelBuilder.Entity<InfClimat>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeAmenagement>().ToTable("INF_CD_AMENAGEMENT", "INF");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code) .HasColumnName("INF_CD_AMENAGEMENT__CODE");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id) .HasColumnName("INF_CD_AMENAGEMENT__ID");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Libelle) .HasColumnName("INF_CD_AMENAGEMENT__LIBELLE");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeAmenagement>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeBifurcation>().ToTable("INF_CD_BIFURCATION", "INF");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code) .HasColumnName("INF_CD_BIFURCATION__CODE");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id) .HasColumnName("INF_CD_BIFURCATION__ID");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Libelle) .HasColumnName("INF_CD_BIFURCATION__LIBELLE");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeBifurcation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeClimat>().ToTable("INF_CD_CLIMAT", "INF");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code) .HasColumnName("INF_CD_CLIMAT__CODE");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id) .HasColumnName("INF_CD_CLIMAT__ID");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Libelle) .HasColumnName("INF_CD_CLIMAT__LIBELLE");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeClimat>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeDec>().HasRequired<InfFamDec>(c => c.InfFamDec).WithMany(t => t.InfCodeDecs);
            modelBuilder.Entity<InfCodeDec>().ToTable("INF_CD_DEC", "INF");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code) .HasColumnName("INF_CD_DEC__CODE");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id) .HasColumnName("INF_CD_DEC__ID");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.InfFamDecId) .HasColumnName("INF_FAM_DEC__ID");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.InfFamDecId).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Libelle) .HasColumnName("INF_CD_DEC__LIBELLE");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeEclairage>().ToTable("INF_CD_ECLAIRAGE", "INF");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code) .HasColumnName("INF_CD_ECLAIRAGE__CODE");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id) .HasColumnName("INF_CD_ECLAIRAGE__ID");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Libelle) .HasColumnName("INF_CD_ECLAIRAGE__LIBELLE");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeEclairage>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeGare>().ToTable("INF_CD_GARE", "INF");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code) .HasColumnName("INF_CD_GARE__CODE");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id) .HasColumnName("INF_CD_GARE__ID");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Libelle) .HasColumnName("INF_CD_GARE__LIBELLE");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeGare>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeOccupant>().ToTable("INF_CD_OCCUPANT", "INF");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code) .HasColumnName("INF_CD_OCCUPANT__CODE");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id) .HasColumnName("INF_CD_OCCUPANT__ID");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Libelle) .HasColumnName("INF_CD_OCCUPANT__LIBELLE");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeOccupant>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeOccupation>().ToTable("INF_CD_OCCUPATION", "INF");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code) .HasColumnName("INF_CD_OCCUPATION__CODE");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id) .HasColumnName("INF_CD_OCCUPATION__ID");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Libelle) .HasColumnName("INF_CD_OCCUPATION__LIBELLE");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeOccupation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePtSing>().ToTable("INF_CD_PT_SING", "INF");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code) .HasColumnName("INF_CD_PT_SING__CODE");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id) .HasColumnName("INF_CD_PT_SING__ID");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Libelle) .HasColumnName("INF_CD_PT_SING__LIBELLE");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodePtSing>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePosit>().ToTable("INF_CD_POSIT", "INF");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id) .HasColumnName("INF_CD_POSIT__ID");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Ordre) .HasColumnName("INF_CD_POSIT__ORDRE");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Position) .HasColumnName("INF_CD_POSIT__POSITION");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Position).IsRequired();
            modelBuilder.Entity<InfCodePosit>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeSecurite>().ToTable("INF_CD_SECURITE", "INF");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code) .HasColumnName("INF_CD_SECURITE__CODE");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id) .HasColumnName("INF_CD_SECURITE__ID");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Libelle) .HasColumnName("INF_CD_SECURITE__LIBELLE");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeSecurite>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeSensible>().ToTable("INF_CD_SENSIBLE", "INF");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code) .HasColumnName("INF_CD_SENSIBLE__CODE");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id) .HasColumnName("INF_CD_SENSIBLE__ID");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Libelle) .HasColumnName("INF_CD_SENSIBLE__LIBELLE");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeSensible>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTalus>().ToTable("INF_CD_TALUS", "INF");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code) .HasColumnName("INF_CD_TALUS__CODE");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id) .HasColumnName("INF_CD_TALUS__ID");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Libelle) .HasColumnName("INF_CD_TALUS__LIBELLE");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTalus>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTpc>().ToTable("INF_CD_TPC", "INF");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code) .HasColumnName("INF_CD_TPC__CODE");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id) .HasColumnName("INF_CD_TPC__ID");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Libelle) .HasColumnName("INF_CD_TPC__LIBELLE");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTpc>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeVoie>().ToTable("INF_CD_VOIE", "INF");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code) .HasColumnName("INF_CD_VOIE__CODE");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id) .HasColumnName("INF_CD_VOIE__ID");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Libelle) .HasColumnName("INF_CD_VOIE__LIBELLE");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Position) .HasColumnName("INF_CD_VOIE__POSITION");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Position).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Roulable) .HasColumnName("INF_CD_VOIE__ROULABLE");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Roulable).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfCodeEclairage>(c => c.InfCodeEclairage).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfCodePosit>(c => c.InfCodePosit).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().ToTable("INF_ECLAIRAGE", "INF");
            modelBuilder.Entity<InfEclairage>().Property(t => t.AbsDeb) .HasColumnName("INF_ECLAIRAGE__ABS_DEB");
            modelBuilder.Entity<InfEclairage>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id) .HasColumnName("INF_ECLAIRAGE__ID");
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodeEclairageId) .HasColumnName("INF_CD_ECLAIRAGE__ID");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodeEclairageId).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodePositId) .HasColumnName("INF_CD_POSIT__ID");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodePositId).IsRequired();
            modelBuilder.Entity<InfEclairage>().HasKey(t => t.Id);
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfFamDec>().ToTable("INF_FAM_DEC", "INF");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code) .HasColumnName("INF_FAM_DEC__CODE");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id) .HasColumnName("INF_FAM_DEC__ID");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(t => t.Libelle) .HasColumnName("INF_FAM_DEC__LIBELLE");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfFamDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfGare>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfGares);
            modelBuilder.Entity<InfGare>().HasRequired<InfCodeGare>(c => c.InfCodeGare).WithMany(t => t.InfGares);
            modelBuilder.Entity<InfGare>().ToTable("INF_GARE", "INF");
            modelBuilder.Entity<InfGare>().Property(t => t.Info) .HasColumnName("INF_GARE__INFO");
            modelBuilder.Entity<InfGare>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfGare>().Property(t => t.DateMs) .HasColumnName("INF_GARE__DATE_MS");
            modelBuilder.Entity<InfGare>().Property(t => t.AbsDeb) .HasColumnName("INF_GARE__ABS_DEB");
            modelBuilder.Entity<InfGare>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.Id) .HasColumnName("INF_GARE__ID");
            modelBuilder.Entity<InfGare>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfGare>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.InfCodeGareId) .HasColumnName("INF_CD_GARE__ID");
            modelBuilder.Entity<InfGare>().Property(t => t.InfCodeGareId).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.NumExploit) .HasColumnName("INF_GARE__NUM_EXPLOIT");
            modelBuilder.Entity<InfGare>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfGare>().Property(t => t.NbSortie) .HasColumnName("INF_GARE__NB_SORTIE");
            modelBuilder.Entity<InfGare>().Property(t => t.NbEntree) .HasColumnName("INF_GARE__NB_ENTREE");
            modelBuilder.Entity<InfGare>().Property(t => t.NbMixte) .HasColumnName("INF_GARE__NB_MIXTE");
            modelBuilder.Entity<InfGare>().Property(t => t.NbTsa) .HasColumnName("INF_GARE__NB_TSA");
            modelBuilder.Entity<InfGare>().Property(t => t.Nom) .HasColumnName("INF_GARE__NOM");
            modelBuilder.Entity<InfGare>().Property(t => t.Nom).HasMaxLength(200);
            modelBuilder.Entity<InfGare>().HasKey(t => t.Id);
            modelBuilder.Entity<InfGare>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfLiaison>().HasRequired<InfCodeLiaison>(c => c.InfCodeLiaison).WithMany(t => t.InfLiaisons);
            modelBuilder.Entity<InfLiaison>().ToTable("INF_LIAISON", "INF");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code) .HasColumnName("INF_LIAISON__CODE");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id) .HasColumnName("INF_LIAISON__ID");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.InfCodeLiaisonId) .HasColumnName("INF_CD_LIAISON__ID");
            modelBuilder.Entity<InfLiaison>().Property(t => t.InfCodeLiaisonId).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.Libelle) .HasColumnName("INF_LIAISON__LIBELLE");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfLiaison>().HasKey(t => t.Id);
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfCodeOccupant>(c => c.InfCodeOccupant).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfCodeOccupation>(c => c.InfCodeOccupation).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().ToTable("INF_OCCUPATION", "INF");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Info) .HasColumnName("INF_OCCUPATION__INFO");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfOccupation>().Property(t => t.DateFg) .HasColumnName("INF_OCCUPATION__DATE_FG");
            modelBuilder.Entity<InfOccupation>().Property(t => t.DateMs) .HasColumnName("INF_OCCUPATION__DATE_MS");
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsDeb) .HasColumnName("INF_OCCUPATION__ABS_DEB");
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsFin) .HasColumnName("INF_OCCUPATION__ABS_FIN");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id) .HasColumnName("INF_OCCUPATION__ID");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupantId) .HasColumnName("INF_CD_OCCUPANT__ID");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupantId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupationId) .HasColumnName("INF_CD_OCCUPATION__ID");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupationId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.Traverse) .HasColumnName("INF_OCCUPATION__TRAVERSE");
            modelBuilder.Entity<InfOccupation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPaveVoie>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPaveVoies);
            modelBuilder.Entity<InfPaveVoie>().HasRequired<InfCodeVoie>(c => c.InfCodeVoie).WithMany(t => t.InfPaveVoies);
            modelBuilder.Entity<InfPaveVoie>().ToTable("INF_PAVE_VOIE", "INF");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.DateMs) .HasColumnName("INF_PAVE_VOIE__DATE_MS");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.DateMs).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsDeb) .HasColumnName("INF_PAVE_VOIE__ABS_DEB");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsFin) .HasColumnName("INF_PAVE_VOIE__ABS_FIN");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id) .HasColumnName("INF_PAVE_VOIE__ID");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfCodeVoieId) .HasColumnName("INF_CD_VOIE__ID");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfCodeVoieId).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Largeur) .HasColumnName("INF_PAVE_VOIE__LARGEUR");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Largeur).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPk>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPks);
            modelBuilder.Entity<InfPk>().ToTable("INF_PK", "INF");
            modelBuilder.Entity<InfPk>().Property(t => t.AbsCum) .HasColumnName("INF_PK__ABS_CUM");
            modelBuilder.Entity<InfPk>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Inter) .HasColumnName("INF_PK__INTER");
            modelBuilder.Entity<InfPk>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Id) .HasColumnName("INF_PK__ID");
            modelBuilder.Entity<InfPk>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfPk>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Num) .HasColumnName("INF_PK__NUM");
            modelBuilder.Entity<InfPk>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfPk>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPk>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPtSing>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPtSings);
            modelBuilder.Entity<InfPtSing>().HasRequired<InfCodePtSing>(c => c.InfCodePtSing).WithMany(t => t.InfPtSings);
            modelBuilder.Entity<InfPtSing>().ToTable("INF_PT_SING", "INF");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Info) .HasColumnName("INF_PT_SING__INFO");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfPtSing>().Property(t => t.AbsDeb) .HasColumnName("INF_PT_SING__ABS_DEB");
            modelBuilder.Entity<InfPtSing>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id) .HasColumnName("INF_PT_SING__ID");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfCodePtSingId) .HasColumnName("INF_CD_PT_SING__ID");
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfCodePtSingId).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.Libelle) .HasColumnName("INF_PT_SING__LIBELLE");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfPtSing>().Property(t => t.Nom) .HasColumnName("INF_PT_SING__NOM");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfPtSing>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfRepartitionTrafic>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfRepartitionTrafics);
            modelBuilder.Entity<InfRepartitionTrafic>().ToTable("INF_REPARTITION_TRAFIC", "INF");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.PcPl) .HasColumnName("INF_REPARTITION_TRAFIC__PC_PL");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Annee) .HasColumnName("INF_REPARTITION_TRAFIC__ANNEE");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Annee).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsDeb) .HasColumnName("INF_REPARTITION_TRAFIC__ABS_DEB");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsFin) .HasColumnName("INF_REPARTITION_TRAFIC__ABS_FIN");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id) .HasColumnName("INF_REPARTITION_TRAFIC__ID");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfRepere>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfReperes);
            modelBuilder.Entity<InfRepere>().ToTable("INF_REPERE", "INF");
            modelBuilder.Entity<InfRepere>().Property(t => t.AbsCum) .HasColumnName("INF_REPERE__ABS_CUM");
            modelBuilder.Entity<InfRepere>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Inter) .HasColumnName("INF_REPERE__INTER");
            modelBuilder.Entity<InfRepere>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Id) .HasColumnName("INF_REPERE__ID");
            modelBuilder.Entity<InfRepere>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfRepere>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Num) .HasColumnName("INF_REPERE__NUM");
            modelBuilder.Entity<InfRepere>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfRepere>().HasKey(t => t.Id);
            modelBuilder.Entity<InfRepere>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSectionTrafic>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSectionTrafics);
            modelBuilder.Entity<InfSectionTrafic>().HasRequired<InfCodeTrafic>(c => c.InfCodeTrafic).WithMany(t => t.InfSectionTrafics);
            modelBuilder.Entity<InfSectionTrafic>().ToTable("INF_SECTION_TRAFIC", "INF");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.About) .HasColumnName("INF_SECTION_TRAFIC__ABOUT");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.About).HasMaxLength(200);
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsDeb) .HasColumnName("INF_SECTION_TRAFIC__ABS_DEB");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsFin) .HasColumnName("INF_SECTION_TRAFIC__ABS_FIN");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id) .HasColumnName("INF_SECTION_TRAFIC__ID");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfCodeTraficId) .HasColumnName("INF_CD_TRAFIC__ID");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfCodeTraficId).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Tenant) .HasColumnName("INF_SECTION_TRAFIC__TENANT");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Tenant).HasMaxLength(200);
            modelBuilder.Entity<InfSectionTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfCodePosit>(c => c.InfCodePosit).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfCodeSecurite>(c => c.InfCodeSecurite).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().ToTable("INF_SECURITE", "INF");
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsDeb) .HasColumnName("INF_SECURITE__ABS_DEB");
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsFin) .HasColumnName("INF_SECURITE__ABS_FIN");
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id) .HasColumnName("INF_SECURITE__ID");
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodePositId) .HasColumnName("INF_CD_POSIT__ID");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodePositId).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodeSecuriteId) .HasColumnName("INF_CD_SECURITE__ID");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodeSecuriteId).IsRequired();
            modelBuilder.Entity<InfSecurite>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSensible>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSensibles);
            modelBuilder.Entity<InfSensible>().HasRequired<InfCodeSensible>(c => c.InfCodeSensible).WithMany(t => t.InfSensibles);
            modelBuilder.Entity<InfSensible>().ToTable("INF_SENSIBLE", "INF");
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsDeb) .HasColumnName("INF_SENSIBLE__ABS_DEB");
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsFin) .HasColumnName("INF_SENSIBLE__ABS_FIN");
            modelBuilder.Entity<InfSensible>().Property(t => t.Id) .HasColumnName("INF_SENSIBLE__ID");
            modelBuilder.Entity<InfSensible>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfSensible>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.InfCodeSensibleId) .HasColumnName("INF_CD_SENSIBLE__ID");
            modelBuilder.Entity<InfSensible>().Property(t => t.InfCodeSensibleId).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.Libelle) .HasColumnName("INF_SENSIBLE__LIBELLE");
            modelBuilder.Entity<InfSensible>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfSensible>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSensible>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTalus>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTaluss);
            modelBuilder.Entity<InfTalus>().HasRequired<InfCodeTalus>(c => c.InfCodeTalus).WithMany(t => t.InfTaluss);
            modelBuilder.Entity<InfTalus>().ToTable("INF_TALUS", "INF");
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsDeb) .HasColumnName("INF_TALUS__ABS_DEB");
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsFin) .HasColumnName("INF_TALUS__ABS_FIN");
            modelBuilder.Entity<InfTalus>().Property(t => t.Hauteur) .HasColumnName("INF_TALUS__HAUTEUR");
            modelBuilder.Entity<InfTalus>().Property(t => t.Id) .HasColumnName("INF_TALUS__ID");
            modelBuilder.Entity<InfTalus>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfTalus>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.InfCodeTalusId) .HasColumnName("INF_CD_TALUS__ID");
            modelBuilder.Entity<InfTalus>().Property(t => t.InfCodeTalusId).IsRequired();
            modelBuilder.Entity<InfTalus>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTalus>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTpc>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTpcs);
            modelBuilder.Entity<InfTpc>().HasRequired<InfCodeTpc>(c => c.InfCodeTpc).WithMany(t => t.InfTpcs);
            modelBuilder.Entity<InfTpc>().ToTable("INF_TPC", "INF");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsDeb) .HasColumnName("INF_TPC__ABS_DEB");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsFin) .HasColumnName("INF_TPC__ABS_FIN");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.Id) .HasColumnName("INF_TPC__ID");
            modelBuilder.Entity<InfTpc>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfTpc>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.InfCodeTpcId) .HasColumnName("INF_CD_TPC__ID");
            modelBuilder.Entity<InfTpc>().Property(t => t.InfCodeTpcId).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.Largeur) .HasColumnName("INF_TPC__LARGEUR");
            modelBuilder.Entity<InfTpc>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTpc>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTrDec>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTrDecs);
            modelBuilder.Entity<InfTrDec>().HasRequired<InfCodeDec>(c => c.InfCodeDec).WithMany(t => t.InfTrDecs);
            modelBuilder.Entity<InfTrDec>().ToTable("INF_TR_DEC", "INF");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsDeb) .HasColumnName("INF_TR_DEC__ABS_DEB");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsFin) .HasColumnName("INF_TR_DEC__ABS_FIN");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id) .HasColumnName("INF_TR_DEC__ID");
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfChausseeId) .HasColumnName("INF_CHAUSSEE__ID");
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfCodeDecId) .HasColumnName("INF_CD_DEC__ID");
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfCodeDecId).IsRequired();
            modelBuilder.Entity<InfTrDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeLiaison>().ToTable("INF_CD_LIAISON", "INF");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code) .HasColumnName("INF_CD_LIAISON__CODE");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id) .HasColumnName("INF_CD_LIAISON__ID");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Libelle) .HasColumnName("INF_CD_LIAISON__LIBELLE");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeLiaison>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }



    }
}

