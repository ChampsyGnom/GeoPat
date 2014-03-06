using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Services;
namespace Emash.GeoPatNet.Data
{
    public class DataContext : IDataContext
    {
	    private DbModelBuilder _modelBuilder;
        public override DbModelBuilder ModelBuilder
        {
            get { return _modelBuilder; }
        }

        public DbSet<SigLayer>  SigLayers
        {
            get;
            set;
        }
        public DbSet<SigNode>  SigNodes
        {
            get;
            set;
        }
        public DbSet<SigTemplate>  SigTemplates
        {
            get;
            set;
        }
        public DbSet<SigCodeLayer>  SigCodeLayers
        {
            get;
            set;
        }
        public DbSet<SigCodeNode>  SigCodeNodes
        {
            get;
            set;
        }
        public DbSet<SigCodeTemplate>  SigCodeTemplates
        {
            get;
            set;
        }
        public DbSet<PrfUser>  PrfUsers
        {
            get;
            set;
        }
        public DbSet<InfAccident>  InfAccidents
        {
            get;
            set;
        }
        public DbSet<InfAireParking>  InfAireParkings
        {
            get;
            set;
        }
        public DbSet<InfAirePrestataire>  InfAirePrestataires
        {
            get;
            set;
        }
        public DbSet<InfAireService>  InfAireServices
        {
            get;
            set;
        }
        public DbSet<InfAire>  InfAires
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
        public DbSet<InfCodeDashboard>  InfCodeDashboards
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
        public DbSet<InfPrestataire>  InfPrestataires
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
        public DbSet<InfDashboard>  InfDashboards
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
        public DbSet<InfCodeAire>  InfCodeAires
        {
            get;
            set;
        }
        public DbSet<InfCodeLiaison>  InfCodeLiaisons
        {
            get;
            set;
        }
        public DbSet<InfCodePlace>  InfCodePlaces
        {
            get;
            set;
        }
        public DbSet<InfCodePrestataire>  InfCodePrestataires
        {
            get;
            set;
        }
        public DbSet<InfCodeService>  InfCodeServices
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
            modelBuilder.Entity<SigLayer>().HasRequired<SigCodeLayer>(c => c.SigCodeLayer).WithMany(t => t.SigLayers);
            modelBuilder.Entity<SigLayer>().ToTable("sig_layer", "sig");
            modelBuilder.Entity<SigLayer>().Property(t => t.Id) .HasColumnName("sig_layer__id");
            modelBuilder.Entity<SigLayer>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigLayer>().Property(t => t.SigCodeLayerId) .HasColumnName("sig_cd_layer__id");
            modelBuilder.Entity<SigLayer>().Property(t => t.SigCodeLayerId).IsRequired();
            modelBuilder.Entity<SigLayer>().Property(t => t.Libelle) .HasColumnName("sig_layer__libelle");
            modelBuilder.Entity<SigLayer>().Property(t => t.Libelle).IsRequired();
            modelBuilder.Entity<SigLayer>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<SigLayer>().Property(t => t.MapOrder) .HasColumnName("sig_layer__map_order");
            modelBuilder.Entity<SigLayer>().Property(t => t.MapOrder).IsRequired();
            modelBuilder.Entity<SigLayer>().HasKey(t => t.Id);
            modelBuilder.Entity<SigLayer>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SigNode>().HasRequired<SigCodeNode>(c => c.SigCodeNode).WithMany(t => t.SigNodes);
            modelBuilder.Entity<SigNode>().HasRequired<SigTemplate>(c => c.SigTemplate).WithMany(t => t.SigNodes);
            modelBuilder.Entity<SigNode>().HasRequired<SigLayer>(c => c.SigLayer).WithMany(t => t.SigNodes);
            modelBuilder.Entity<SigNode>().ToTable("sig_node", "sig");
            modelBuilder.Entity<SigNode>().Property(t => t.Id) .HasColumnName("sig_node__id");
            modelBuilder.Entity<SigNode>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigNode>().Property(t => t.SigLayerId) .HasColumnName("sig_layer__id");
            modelBuilder.Entity<SigNode>().Property(t => t.SigTemplateId) .HasColumnName("sig_template__id");
            modelBuilder.Entity<SigNode>().Property(t => t.SigTemplateId).IsRequired();
            modelBuilder.Entity<SigNode>().Property(t => t.SigCodeNodeId) .HasColumnName("sig_cd_node__id");
            modelBuilder.Entity<SigNode>().Property(t => t.SigCodeNodeId).IsRequired();
            modelBuilder.Entity<SigNode>().Property(t => t.Libelle) .HasColumnName("sig_node__libelle");
            modelBuilder.Entity<SigNode>().Property(t => t.Libelle).IsRequired();
            modelBuilder.Entity<SigNode>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<SigNode>().Property(t => t.ParentId) .HasColumnName("sig_node__parent_id");
            modelBuilder.Entity<SigNode>().Property(t => t.Order) .HasColumnName("sig_node__order");
            modelBuilder.Entity<SigNode>().Property(t => t.Order).IsRequired();
            modelBuilder.Entity<SigNode>().HasKey(t => t.Id);
            modelBuilder.Entity<SigNode>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SigTemplate>().HasRequired<SigCodeTemplate>(c => c.SigCodeTemplate).WithMany(t => t.SigTemplates);
            modelBuilder.Entity<SigTemplate>().ToTable("sig_template", "sig");
            modelBuilder.Entity<SigTemplate>().Property(t => t.Id) .HasColumnName("sig_template__id");
            modelBuilder.Entity<SigTemplate>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigTemplate>().Property(t => t.SigCodeTemplateId) .HasColumnName("sig_cd_template__id");
            modelBuilder.Entity<SigTemplate>().Property(t => t.SigCodeTemplateId).IsRequired();
            modelBuilder.Entity<SigTemplate>().Property(t => t.Libelle) .HasColumnName("sig_template__libelle");
            modelBuilder.Entity<SigTemplate>().Property(t => t.Libelle).IsRequired();
            modelBuilder.Entity<SigTemplate>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<SigTemplate>().HasKey(t => t.Id);
            modelBuilder.Entity<SigTemplate>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SigCodeLayer>().ToTable("sig_cd_layer", "sig");
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Code) .HasColumnName("sig_cd_layer__code");
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Id) .HasColumnName("sig_cd_layer__id");
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Libelle) .HasColumnName("sig_cd_layer__libelle");
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Libelle).HasMaxLength(500);
            modelBuilder.Entity<SigCodeLayer>().HasKey(t => t.Id);
            modelBuilder.Entity<SigCodeLayer>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SigCodeNode>().ToTable("sig_cd_node", "sig");
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Code) .HasColumnName("sig_cd_node__code");
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Id) .HasColumnName("sig_cd_node__id");
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Libelle) .HasColumnName("sig_cd_node__libelle");
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<SigCodeNode>().HasKey(t => t.Id);
            modelBuilder.Entity<SigCodeNode>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SigCodeTemplate>().ToTable("sig_cd_template", "sig");
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Code) .HasColumnName("sig_cd_template__code");
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Id) .HasColumnName("sig_cd_template__id");
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Libelle) .HasColumnName("sig_cd_template__libelle");
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<SigCodeTemplate>().HasKey(t => t.Id);
            modelBuilder.Entity<SigCodeTemplate>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PrfUser>().ToTable("prf_user", "prf");
            modelBuilder.Entity<PrfUser>().Property(t => t.Id) .HasColumnName("prf_user__id");
            modelBuilder.Entity<PrfUser>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<PrfUser>().Property(t => t.Login) .HasColumnName("prf_user__login");
            modelBuilder.Entity<PrfUser>().Property(t => t.Login).IsRequired();
            modelBuilder.Entity<PrfUser>().Property(t => t.Login).HasMaxLength(50);
            modelBuilder.Entity<PrfUser>().Property(t => t.Nom) .HasColumnName("prf_user__nom");
            modelBuilder.Entity<PrfUser>().Property(t => t.Nom).IsRequired();
            modelBuilder.Entity<PrfUser>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<PrfUser>().Property(t => t.Passsword) .HasColumnName("prf_user__passsword");
            modelBuilder.Entity<PrfUser>().Property(t => t.Passsword).HasMaxLength(50);
            modelBuilder.Entity<PrfUser>().Property(t => t.Prenom) .HasColumnName("prf_user__prenom");
            modelBuilder.Entity<PrfUser>().Property(t => t.Prenom).IsRequired();
            modelBuilder.Entity<PrfUser>().Property(t => t.Prenom).HasMaxLength(50);
            modelBuilder.Entity<PrfUser>().HasKey(t => t.Id);
            modelBuilder.Entity<PrfUser>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAccident>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfAccidents);
            modelBuilder.Entity<InfAccident>().ToTable("inf_accident", "inf");
            modelBuilder.Entity<InfAccident>().Property(t => t.Annee) .HasColumnName("inf_accident__annee");
            modelBuilder.Entity<InfAccident>().Property(t => t.Annee).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsDeb) .HasColumnName("inf_accident__abs_deb");
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.AbsFin) .HasColumnName("inf_accident__abs_fin");
            modelBuilder.Entity<InfAccident>().Property(t => t.Id) .HasColumnName("inf_accident__id");
            modelBuilder.Entity<InfAccident>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfAccident>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.Mois) .HasColumnName("inf_accident__mois");
            modelBuilder.Entity<InfAccident>().Property(t => t.Mois).IsRequired();
            modelBuilder.Entity<InfAccident>().Property(t => t.Nb) .HasColumnName("inf_accident__nb");
            modelBuilder.Entity<InfAccident>().Property(t => t.NbMois) .HasColumnName("inf_accident__nb_mois");
            modelBuilder.Entity<InfAccident>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAccident>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAireParking>().HasRequired<InfAire>(c => c.InfAire).WithMany(t => t.InfAireParkings);
            modelBuilder.Entity<InfAireParking>().HasRequired<InfCodePlace>(c => c.InfCodePlace).WithMany(t => t.InfAireParkings);
            modelBuilder.Entity<InfAireParking>().ToTable("inf_aire_parking", "inf");
            modelBuilder.Entity<InfAireParking>().Property(t => t.Id) .HasColumnName("inf_aire_parking__id");
            modelBuilder.Entity<InfAireParking>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAireParking>().Property(t => t.InfAireId) .HasColumnName("inf_aire__id");
            modelBuilder.Entity<InfAireParking>().Property(t => t.InfCodePlaceId) .HasColumnName("inf_cd_place__id");
            modelBuilder.Entity<InfAireParking>().Property(t => t.NbPlace) .HasColumnName("inf_aire_parking__nb_place");
            modelBuilder.Entity<InfAireParking>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAireParking>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAirePrestataire>().HasRequired<InfAire>(c => c.InfAire).WithMany(t => t.InfAirePrestataires);
            modelBuilder.Entity<InfAirePrestataire>().HasRequired<InfPrestataire>(c => c.InfPrestataire).WithMany(t => t.InfAirePrestataires);
            modelBuilder.Entity<InfAirePrestataire>().ToTable("inf_aire_prestataire", "inf");
            modelBuilder.Entity<InfAirePrestataire>().Property(t => t.Id) .HasColumnName("inf_aire_prestataire__id");
            modelBuilder.Entity<InfAirePrestataire>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAirePrestataire>().Property(t => t.InfAireId) .HasColumnName("inf_aire__id");
            modelBuilder.Entity<InfAirePrestataire>().Property(t => t.InfPrestataireId) .HasColumnName("inf_prestataire__id");
            modelBuilder.Entity<InfAirePrestataire>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAirePrestataire>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAireService>().HasRequired<InfAire>(c => c.InfAire).WithMany(t => t.InfAireServices);
            modelBuilder.Entity<InfAireService>().HasRequired<InfCodeService>(c => c.InfCodeService).WithMany(t => t.InfAireServices);
            modelBuilder.Entity<InfAireService>().ToTable("inf_aire_service", "inf");
            modelBuilder.Entity<InfAireService>().Property(t => t.Id) .HasColumnName("inf_aire_service__id");
            modelBuilder.Entity<InfAireService>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAireService>().Property(t => t.InfAireId) .HasColumnName("inf_aire__id");
            modelBuilder.Entity<InfAireService>().Property(t => t.InfCodeServiceId) .HasColumnName("inf_cd_service__id");
            modelBuilder.Entity<InfAireService>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAireService>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAire>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfAires);
            modelBuilder.Entity<InfAire>().HasRequired<InfCodeAire>(c => c.InfCodeAire).WithMany(t => t.InfAires);
            modelBuilder.Entity<InfAire>().ToTable("inf_aire", "inf");
            modelBuilder.Entity<InfAire>().Property(t => t.Bilaterale) .HasColumnName("inf_aire__bilaterale");
            modelBuilder.Entity<InfAire>().Property(t => t.Observ) .HasColumnName("inf_aire__observ");
            modelBuilder.Entity<InfAire>().Property(t => t.Observ).HasMaxLength(250);
            modelBuilder.Entity<InfAire>().Property(t => t.DateMs) .HasColumnName("inf_aire__date_ms");
            modelBuilder.Entity<InfAire>().Property(t => t.AbsDeb) .HasColumnName("inf_aire__abs_deb");
            modelBuilder.Entity<InfAire>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAire>().Property(t => t.DemiTour) .HasColumnName("inf_aire__demi_tour");
            modelBuilder.Entity<InfAire>().Property(t => t.Id) .HasColumnName("inf_aire__id");
            modelBuilder.Entity<InfAire>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAire>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfAire>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfAire>().Property(t => t.InfCodeAireId) .HasColumnName("inf_cd_aire__id");
            modelBuilder.Entity<InfAire>().Property(t => t.InfCodeAireId).IsRequired();
            modelBuilder.Entity<InfAire>().Property(t => t.NumExploit) .HasColumnName("inf_aire__num_exploit");
            modelBuilder.Entity<InfAire>().Property(t => t.NumExploit).HasMaxLength(15);
            modelBuilder.Entity<InfAire>().Property(t => t.Nom) .HasColumnName("inf_aire__nom");
            modelBuilder.Entity<InfAire>().Property(t => t.Nom).HasMaxLength(60);
            modelBuilder.Entity<InfAire>().Property(t => t.Passerelle) .HasColumnName("inf_aire__passerelle");
            modelBuilder.Entity<InfAire>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAire>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfAmenagement>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfAmenagements);
            modelBuilder.Entity<InfAmenagement>().HasRequired<InfCodeAmenagement>(c => c.InfCodeAmenagement).WithMany(t => t.InfAmenagements);
            modelBuilder.Entity<InfAmenagement>().ToTable("inf_amenagement", "inf");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Info) .HasColumnName("inf_amenagement__info");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Cout) .HasColumnName("inf_amenagement__cout");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateDeb) .HasColumnName("inf_amenagement__date_deb");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.DateFin) .HasColumnName("inf_amenagement__date_fin");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsDeb) .HasColumnName("inf_amenagement__abs_deb");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.AbsFin) .HasColumnName("inf_amenagement__abs_fin");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id) .HasColumnName("inf_amenagement__id");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfCodeAmenagementId) .HasColumnName("inf_cd_amenagement__id");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfCodeAmenagementId).IsRequired();
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfAmenagement>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfAmenagement>().HasKey(t => t.Id);
            modelBuilder.Entity<InfAmenagement>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPrOld>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPrOlds);
            modelBuilder.Entity<InfPrOld>().ToTable("inf_pr_old", "inf");
            modelBuilder.Entity<InfPrOld>().Property(t => t.AbsCum) .HasColumnName("inf_pr_old__abs_cum");
            modelBuilder.Entity<InfPrOld>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Inter) .HasColumnName("inf_pr_old__inter");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id) .HasColumnName("inf_pr_old__id");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfPrOld>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPrOld>().Property(t => t.Num) .HasColumnName("inf_pr_old__num");
            modelBuilder.Entity<InfPrOld>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfPrOld>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPrOld>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfBifurcation>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfBifurcations);
            modelBuilder.Entity<InfBifurcation>().HasRequired<InfCodeBifurcation>(c => c.InfCodeBifurcation).WithMany(t => t.InfBifurcations);
            modelBuilder.Entity<InfBifurcation>().ToTable("inf_bifurcation", "inf");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Info) .HasColumnName("inf_bifurcation__info");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.DateMs) .HasColumnName("inf_bifurcation__date_ms");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.AbsDeb) .HasColumnName("inf_bifurcation__abs_deb");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id) .HasColumnName("inf_bifurcation__id");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfCodeBifurcationId) .HasColumnName("inf_cd_bifurcation__id");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfCodeBifurcationId).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfBifurcation>().Property(t => t.NumExploit) .HasColumnName("inf_bifurcation__num_exploit");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Nom) .HasColumnName("inf_bifurcation__nom");
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfBifurcation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfBifurcation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfBretelle>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfBretelles);
            modelBuilder.Entity<InfBretelle>().ToTable("inf_bretelle", "inf");
            modelBuilder.Entity<InfBretelle>().Property(t => t.AbsDeb) .HasColumnName("inf_bretelle__abs_deb");
            modelBuilder.Entity<InfBretelle>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.Extremite) .HasColumnName("inf_bretelle__extremite");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Extremite).HasMaxLength(100);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id) .HasColumnName("inf_bretelle__id");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfBretelle>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfBretelle>().Property(t => t.Libelle) .HasColumnName("inf_bretelle__libelle");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Num) .HasColumnName("inf_bretelle__num");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Num).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().Property(t => t.NumExploit) .HasColumnName("inf_bretelle__num_exploit");
            modelBuilder.Entity<InfBretelle>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Nom) .HasColumnName("inf_bretelle__nom");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Type) .HasColumnName("inf_bretelle__type");
            modelBuilder.Entity<InfBretelle>().Property(t => t.Type).HasMaxLength(50);
            modelBuilder.Entity<InfBretelle>().HasKey(t => t.Id);
            modelBuilder.Entity<InfBretelle>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfChaussee>().HasRequired<InfLiaison>(c => c.InfLiaison).WithMany(t => t.InfChaussees);
            modelBuilder.Entity<InfChaussee>().ToTable("inf_chaussee", "inf");
            modelBuilder.Entity<InfChaussee>().Property(t => t.About) .HasColumnName("inf_chaussee__about");
            modelBuilder.Entity<InfChaussee>().Property(t => t.About).HasMaxLength(200);
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code) .HasColumnName("inf_chaussee__code");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfChaussee>().Property(t => t.AbsDeb) .HasColumnName("inf_chaussee__abs_deb");
            modelBuilder.Entity<InfChaussee>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.AbsFin) .HasColumnName("inf_chaussee__abs_fin");
            modelBuilder.Entity<InfChaussee>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.Geom) .HasColumnName("inf_chaussee__geom");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.InfLiaisonId) .HasColumnName("inf_liaison__id");
            modelBuilder.Entity<InfChaussee>().Property(t => t.InfLiaisonId).IsRequired();
            modelBuilder.Entity<InfChaussee>().Property(t => t.Libelle) .HasColumnName("inf_chaussee__libelle");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfChaussee>().Property(t => t.Tenant) .HasColumnName("inf_chaussee__tenant");
            modelBuilder.Entity<InfChaussee>().Property(t => t.Tenant).HasMaxLength(200);
            modelBuilder.Entity<InfChaussee>().HasKey(t => t.Id);
            modelBuilder.Entity<InfChaussee>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTrafic>().ToTable("inf_cd_trafic", "inf");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code) .HasColumnName("inf_cd_trafic__code");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id) .HasColumnName("inf_cd_trafic__id");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Libelle) .HasColumnName("inf_cd_trafic__libelle");
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfClimat>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfClimats);
            modelBuilder.Entity<InfClimat>().HasRequired<InfCodeClimat>(c => c.InfCodeClimat).WithMany(t => t.InfClimats);
            modelBuilder.Entity<InfClimat>().ToTable("inf_climat", "inf");
            modelBuilder.Entity<InfClimat>().Property(t => t.Info) .HasColumnName("inf_climat__info");
            modelBuilder.Entity<InfClimat>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsDeb) .HasColumnName("inf_climat__abs_deb");
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsFin) .HasColumnName("inf_climat__abs_fin");
            modelBuilder.Entity<InfClimat>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.Id) .HasColumnName("inf_climat__id");
            modelBuilder.Entity<InfClimat>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.InfCodeClimatId) .HasColumnName("inf_cd_climat__id");
            modelBuilder.Entity<InfClimat>().Property(t => t.InfCodeClimatId).IsRequired();
            modelBuilder.Entity<InfClimat>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfClimat>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfClimat>().HasKey(t => t.Id);
            modelBuilder.Entity<InfClimat>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeAmenagement>().ToTable("inf_cd_amenagement", "inf");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code) .HasColumnName("inf_cd_amenagement__code");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id) .HasColumnName("inf_cd_amenagement__id");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Libelle) .HasColumnName("inf_cd_amenagement__libelle");
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeAmenagement>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeAmenagement>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeBifurcation>().ToTable("inf_cd_bifurcation", "inf");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code) .HasColumnName("inf_cd_bifurcation__code");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id) .HasColumnName("inf_cd_bifurcation__id");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Libelle) .HasColumnName("inf_cd_bifurcation__libelle");
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeBifurcation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeBifurcation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeClimat>().ToTable("inf_cd_climat", "inf");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code) .HasColumnName("inf_cd_climat__code");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id) .HasColumnName("inf_cd_climat__id");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Libelle) .HasColumnName("inf_cd_climat__libelle");
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeClimat>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeClimat>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeDec>().HasRequired<InfFamDec>(c => c.InfFamDec).WithMany(t => t.InfCodeDecs);
            modelBuilder.Entity<InfCodeDec>().ToTable("inf_cd_dec", "inf");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code) .HasColumnName("inf_cd_dec__code");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id) .HasColumnName("inf_cd_dec__id");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.InfFamDecId) .HasColumnName("inf_fam_dec__id");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.InfFamDecId).IsRequired();
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Libelle) .HasColumnName("inf_cd_dec__libelle");
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeEclairage>().ToTable("inf_cd_eclairage", "inf");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code) .HasColumnName("inf_cd_eclairage__code");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id) .HasColumnName("inf_cd_eclairage__id");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Libelle) .HasColumnName("inf_cd_eclairage__libelle");
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeEclairage>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeEclairage>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeGare>().ToTable("inf_cd_gare", "inf");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code) .HasColumnName("inf_cd_gare__code");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id) .HasColumnName("inf_cd_gare__id");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Libelle) .HasColumnName("inf_cd_gare__libelle");
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeGare>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeGare>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeOccupant>().ToTable("inf_cd_occupant", "inf");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code) .HasColumnName("inf_cd_occupant__code");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id) .HasColumnName("inf_cd_occupant__id");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Libelle) .HasColumnName("inf_cd_occupant__libelle");
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeOccupant>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeOccupant>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeOccupation>().ToTable("inf_cd_occupation", "inf");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code) .HasColumnName("inf_cd_occupation__code");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id) .HasColumnName("inf_cd_occupation__id");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Libelle) .HasColumnName("inf_cd_occupation__libelle");
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeOccupation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeOccupation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePtSing>().ToTable("inf_cd_pt_sing", "inf");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code) .HasColumnName("inf_cd_pt_sing__code");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id) .HasColumnName("inf_cd_pt_sing__id");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Libelle) .HasColumnName("inf_cd_pt_sing__libelle");
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodePtSing>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePtSing>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePosit>().ToTable("inf_cd_posit", "inf");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id) .HasColumnName("inf_cd_posit__id");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Ordre) .HasColumnName("inf_cd_posit__ordre");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Position) .HasColumnName("inf_cd_posit__position");
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Position).IsRequired();
            modelBuilder.Entity<InfCodePosit>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePosit>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeSecurite>().ToTable("inf_cd_securite", "inf");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code) .HasColumnName("inf_cd_securite__code");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id) .HasColumnName("inf_cd_securite__id");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Libelle) .HasColumnName("inf_cd_securite__libelle");
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeSecurite>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeSecurite>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeSensible>().ToTable("inf_cd_sensible", "inf");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code) .HasColumnName("inf_cd_sensible__code");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id) .HasColumnName("inf_cd_sensible__id");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Libelle) .HasColumnName("inf_cd_sensible__libelle");
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeSensible>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeSensible>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeDashboard>().ToTable("inf_cd_dashboard", "inf");
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Code) .HasColumnName("inf_cd_dashboard__code");
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Id) .HasColumnName("inf_cd_dashboard__id");
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Libelle) .HasColumnName("inf_cd_dashboard__libelle");
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeDashboard>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeDashboard>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTalus>().ToTable("inf_cd_talus", "inf");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code) .HasColumnName("inf_cd_talus__code");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id) .HasColumnName("inf_cd_talus__id");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Libelle) .HasColumnName("inf_cd_talus__libelle");
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTalus>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTalus>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeTpc>().ToTable("inf_cd_tpc", "inf");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code) .HasColumnName("inf_cd_tpc__code");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id) .HasColumnName("inf_cd_tpc__id");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Libelle) .HasColumnName("inf_cd_tpc__libelle");
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeTpc>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeTpc>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeVoie>().ToTable("inf_cd_voie", "inf");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code) .HasColumnName("inf_cd_voie__code");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Couleur) .HasColumnName("inf_cd_voie__couleur");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Couleur).HasMaxLength(15);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id) .HasColumnName("inf_cd_voie__id");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Libelle) .HasColumnName("inf_cd_voie__libelle");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Position) .HasColumnName("inf_cd_voie__position");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Position).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Roulable) .HasColumnName("inf_cd_voie__roulable");
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Roulable).IsRequired();
            modelBuilder.Entity<InfCodeVoie>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeVoie>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfCodeEclairage>(c => c.InfCodeEclairage).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().HasRequired<InfCodePosit>(c => c.InfCodePosit).WithMany(t => t.InfEclairages);
            modelBuilder.Entity<InfEclairage>().ToTable("inf_eclairage", "inf");
            modelBuilder.Entity<InfEclairage>().Property(t => t.AbsDeb) .HasColumnName("inf_eclairage__abs_deb");
            modelBuilder.Entity<InfEclairage>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id) .HasColumnName("inf_eclairage__id");
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodeEclairageId) .HasColumnName("inf_cd_eclairage__id");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodeEclairageId).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodePositId) .HasColumnName("inf_cd_posit__id");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfCodePositId).IsRequired();
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfEclairage>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfEclairage>().HasKey(t => t.Id);
            modelBuilder.Entity<InfEclairage>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfFamDec>().ToTable("inf_fam_dec", "inf");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code) .HasColumnName("inf_fam_dec__code");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id) .HasColumnName("inf_fam_dec__id");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfFamDec>().Property(t => t.Libelle) .HasColumnName("inf_fam_dec__libelle");
            modelBuilder.Entity<InfFamDec>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfFamDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfFamDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfGare>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfGares);
            modelBuilder.Entity<InfGare>().HasRequired<InfCodeGare>(c => c.InfCodeGare).WithMany(t => t.InfGares);
            modelBuilder.Entity<InfGare>().ToTable("inf_gare", "inf");
            modelBuilder.Entity<InfGare>().Property(t => t.Info) .HasColumnName("inf_gare__info");
            modelBuilder.Entity<InfGare>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfGare>().Property(t => t.DateMs) .HasColumnName("inf_gare__date_ms");
            modelBuilder.Entity<InfGare>().Property(t => t.AbsDeb) .HasColumnName("inf_gare__abs_deb");
            modelBuilder.Entity<InfGare>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.Id) .HasColumnName("inf_gare__id");
            modelBuilder.Entity<InfGare>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.InfCodeGareId) .HasColumnName("inf_cd_gare__id");
            modelBuilder.Entity<InfGare>().Property(t => t.InfCodeGareId).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfGare>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfGare>().Property(t => t.NumExploit) .HasColumnName("inf_gare__num_exploit");
            modelBuilder.Entity<InfGare>().Property(t => t.NumExploit).HasMaxLength(50);
            modelBuilder.Entity<InfGare>().Property(t => t.NbSortie) .HasColumnName("inf_gare__nb_sortie");
            modelBuilder.Entity<InfGare>().Property(t => t.NbEntree) .HasColumnName("inf_gare__nb_entree");
            modelBuilder.Entity<InfGare>().Property(t => t.NbMixte) .HasColumnName("inf_gare__nb_mixte");
            modelBuilder.Entity<InfGare>().Property(t => t.NbTsa) .HasColumnName("inf_gare__nb_tsa");
            modelBuilder.Entity<InfGare>().Property(t => t.Nom) .HasColumnName("inf_gare__nom");
            modelBuilder.Entity<InfGare>().Property(t => t.Nom).HasMaxLength(200);
            modelBuilder.Entity<InfGare>().HasKey(t => t.Id);
            modelBuilder.Entity<InfGare>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfLiaison>().HasRequired<InfCodeLiaison>(c => c.InfCodeLiaison).WithMany(t => t.InfLiaisons);
            modelBuilder.Entity<InfLiaison>().ToTable("inf_liaison", "inf");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code) .HasColumnName("inf_liaison__code");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id) .HasColumnName("inf_liaison__id");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.InfCodeLiaisonId) .HasColumnName("inf_cd_liaison__id");
            modelBuilder.Entity<InfLiaison>().Property(t => t.InfCodeLiaisonId).IsRequired();
            modelBuilder.Entity<InfLiaison>().Property(t => t.Libelle) .HasColumnName("inf_liaison__libelle");
            modelBuilder.Entity<InfLiaison>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfLiaison>().HasKey(t => t.Id);
            modelBuilder.Entity<InfLiaison>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfCodeOccupant>(c => c.InfCodeOccupant).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().HasRequired<InfCodeOccupation>(c => c.InfCodeOccupation).WithMany(t => t.InfOccupations);
            modelBuilder.Entity<InfOccupation>().ToTable("inf_occupation", "inf");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Info) .HasColumnName("inf_occupation__info");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfOccupation>().Property(t => t.DateFg) .HasColumnName("inf_occupation__date_fg");
            modelBuilder.Entity<InfOccupation>().Property(t => t.DateMs) .HasColumnName("inf_occupation__date_ms");
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsDeb) .HasColumnName("inf_occupation__abs_deb");
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.AbsFin) .HasColumnName("inf_occupation__abs_fin");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id) .HasColumnName("inf_occupation__id");
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupantId) .HasColumnName("inf_cd_occupant__id");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupantId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupationId) .HasColumnName("inf_cd_occupation__id");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfCodeOccupationId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfOccupation>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfOccupation>().Property(t => t.Traverse) .HasColumnName("inf_occupation__traverse");
            modelBuilder.Entity<InfOccupation>().HasKey(t => t.Id);
            modelBuilder.Entity<InfOccupation>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPaveVoie>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPaveVoies);
            modelBuilder.Entity<InfPaveVoie>().HasRequired<InfCodeVoie>(c => c.InfCodeVoie).WithMany(t => t.InfPaveVoies);
            modelBuilder.Entity<InfPaveVoie>().ToTable("inf_pave_voie", "inf");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.DateMs) .HasColumnName("inf_pave_voie__date_ms");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.DateMs).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsDeb) .HasColumnName("inf_pave_voie__abs_deb");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsFin) .HasColumnName("inf_pave_voie__abs_fin");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id) .HasColumnName("inf_pave_voie__id");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfCodeVoieId) .HasColumnName("inf_cd_voie__id");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfCodeVoieId).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Largeur) .HasColumnName("inf_pave_voie__largeur");
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Largeur).IsRequired();
            modelBuilder.Entity<InfPaveVoie>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPaveVoie>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPk>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPks);
            modelBuilder.Entity<InfPk>().ToTable("inf_pk", "inf");
            modelBuilder.Entity<InfPk>().Property(t => t.AbsCum) .HasColumnName("inf_pk__abs_cum");
            modelBuilder.Entity<InfPk>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Inter) .HasColumnName("inf_pk__inter");
            modelBuilder.Entity<InfPk>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Id) .HasColumnName("inf_pk__id");
            modelBuilder.Entity<InfPk>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfPk>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPk>().Property(t => t.Num) .HasColumnName("inf_pk__num");
            modelBuilder.Entity<InfPk>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfPk>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPk>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPtSing>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfPtSings);
            modelBuilder.Entity<InfPtSing>().HasRequired<InfCodePtSing>(c => c.InfCodePtSing).WithMany(t => t.InfPtSings);
            modelBuilder.Entity<InfPtSing>().ToTable("inf_pt_sing", "inf");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Info) .HasColumnName("inf_pt_sing__info");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Info).HasMaxLength(500);
            modelBuilder.Entity<InfPtSing>().Property(t => t.AbsDeb) .HasColumnName("inf_pt_sing__abs_deb");
            modelBuilder.Entity<InfPtSing>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id) .HasColumnName("inf_pt_sing__id");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfCodePtSingId) .HasColumnName("inf_cd_pt_sing__id");
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfCodePtSingId).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfPtSing>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfPtSing>().Property(t => t.Libelle) .HasColumnName("inf_pt_sing__libelle");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfPtSing>().Property(t => t.Nom) .HasColumnName("inf_pt_sing__nom");
            modelBuilder.Entity<InfPtSing>().Property(t => t.Nom).HasMaxLength(100);
            modelBuilder.Entity<InfPtSing>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPtSing>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfPrestataire>().HasRequired<InfCodePrestataire>(c => c.InfCodePrestataire).WithMany(t => t.InfPrestataires);
            modelBuilder.Entity<InfPrestataire>().ToTable("inf_prestataire", "inf");
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Code) .HasColumnName("inf_prestataire__code");
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Id) .HasColumnName("inf_prestataire__id");
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfPrestataire>().Property(t => t.InfCodePrestataireId) .HasColumnName("inf_cd_prestataire__id");
            modelBuilder.Entity<InfPrestataire>().Property(t => t.InfCodePrestataireId).IsRequired();
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Libelle) .HasColumnName("inf_prestataire__libelle");
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfPrestataire>().HasKey(t => t.Id);
            modelBuilder.Entity<InfPrestataire>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfRepartitionTrafic>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfRepartitionTrafics);
            modelBuilder.Entity<InfRepartitionTrafic>().ToTable("inf_repartition_trafic", "inf");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.PcPl) .HasColumnName("inf_repartition_trafic__pc_pl");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Annee) .HasColumnName("inf_repartition_trafic__annee");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Annee).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsDeb) .HasColumnName("inf_repartition_trafic__abs_deb");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.AbsFin) .HasColumnName("inf_repartition_trafic__abs_fin");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id) .HasColumnName("inf_repartition_trafic__id");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfRepartitionTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfRepartitionTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfRepere>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfReperes);
            modelBuilder.Entity<InfRepere>().ToTable("inf_repere", "inf");
            modelBuilder.Entity<InfRepere>().Property(t => t.AbsCum) .HasColumnName("inf_repere__abs_cum");
            modelBuilder.Entity<InfRepere>().Property(t => t.AbsCum).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Inter) .HasColumnName("inf_repere__inter");
            modelBuilder.Entity<InfRepere>().Property(t => t.Inter).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Id) .HasColumnName("inf_repere__id");
            modelBuilder.Entity<InfRepere>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfRepere>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfRepere>().Property(t => t.Num) .HasColumnName("inf_repere__num");
            modelBuilder.Entity<InfRepere>().Property(t => t.Num).IsRequired();
            modelBuilder.Entity<InfRepere>().HasKey(t => t.Id);
            modelBuilder.Entity<InfRepere>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSectionTrafic>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSectionTrafics);
            modelBuilder.Entity<InfSectionTrafic>().HasRequired<InfCodeTrafic>(c => c.InfCodeTrafic).WithMany(t => t.InfSectionTrafics);
            modelBuilder.Entity<InfSectionTrafic>().ToTable("inf_section_trafic", "inf");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.About) .HasColumnName("inf_section_trafic__about");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.About).HasMaxLength(200);
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsDeb) .HasColumnName("inf_section_trafic__abs_deb");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.AbsFin) .HasColumnName("inf_section_trafic__abs_fin");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id) .HasColumnName("inf_section_trafic__id");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfCodeTraficId) .HasColumnName("inf_cd_trafic__id");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfCodeTraficId).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Tenant) .HasColumnName("inf_section_trafic__tenant");
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Tenant).HasMaxLength(200);
            modelBuilder.Entity<InfSectionTrafic>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSectionTrafic>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfCodePosit>(c => c.InfCodePosit).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().HasRequired<InfCodeSecurite>(c => c.InfCodeSecurite).WithMany(t => t.InfSecurites);
            modelBuilder.Entity<InfSecurite>().ToTable("inf_securite", "inf");
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsDeb) .HasColumnName("inf_securite__abs_deb");
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.AbsFin) .HasColumnName("inf_securite__abs_fin");
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id) .HasColumnName("inf_securite__id");
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodePositId) .HasColumnName("inf_cd_posit__id");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodePositId).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodeSecuriteId) .HasColumnName("inf_cd_securite__id");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfCodeSecuriteId).IsRequired();
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfSecurite>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSecurite>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSecurite>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfSensible>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfSensibles);
            modelBuilder.Entity<InfSensible>().HasRequired<InfCodeSensible>(c => c.InfCodeSensible).WithMany(t => t.InfSensibles);
            modelBuilder.Entity<InfSensible>().ToTable("inf_sensible", "inf");
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsDeb) .HasColumnName("inf_sensible__abs_deb");
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.AbsFin) .HasColumnName("inf_sensible__abs_fin");
            modelBuilder.Entity<InfSensible>().Property(t => t.Id) .HasColumnName("inf_sensible__id");
            modelBuilder.Entity<InfSensible>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.InfCodeSensibleId) .HasColumnName("inf_cd_sensible__id");
            modelBuilder.Entity<InfSensible>().Property(t => t.InfCodeSensibleId).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfSensible>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfSensible>().Property(t => t.Libelle) .HasColumnName("inf_sensible__libelle");
            modelBuilder.Entity<InfSensible>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfSensible>().HasKey(t => t.Id);
            modelBuilder.Entity<InfSensible>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfDashboard>().HasRequired<InfCodeDashboard>(c => c.InfCodeDashboard).WithMany(t => t.InfDashboards);
            modelBuilder.Entity<InfDashboard>().ToTable("inf_dashboard", "inf");
            modelBuilder.Entity<InfDashboard>().Property(t => t.Code) .HasColumnName("inf_dashboard__code");
            modelBuilder.Entity<InfDashboard>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfDashboard>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfDashboard>().Property(t => t.Id) .HasColumnName("inf_dashboard__id");
            modelBuilder.Entity<InfDashboard>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfDashboard>().Property(t => t.IdParent) .HasColumnName("inf_dashboard__id_parent");
            modelBuilder.Entity<InfDashboard>().Property(t => t.InfCodeDashboardId) .HasColumnName("inf_cd_dashboard__id");
            modelBuilder.Entity<InfDashboard>().Property(t => t.InfCodeDashboardId).IsRequired();
            modelBuilder.Entity<InfDashboard>().Property(t => t.Libelle) .HasColumnName("inf_dashboard__libelle");
            modelBuilder.Entity<InfDashboard>().Property(t => t.Libelle).IsRequired();
            modelBuilder.Entity<InfDashboard>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfDashboard>().Property(t => t.Ordre) .HasColumnName("inf_dashboard__ordre");
            modelBuilder.Entity<InfDashboard>().Property(t => t.Ordre).IsRequired();
            modelBuilder.Entity<InfDashboard>().HasKey(t => t.Id);
            modelBuilder.Entity<InfDashboard>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTalus>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTaluss);
            modelBuilder.Entity<InfTalus>().HasRequired<InfCodeTalus>(c => c.InfCodeTalus).WithMany(t => t.InfTaluss);
            modelBuilder.Entity<InfTalus>().ToTable("inf_talus", "inf");
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsDeb) .HasColumnName("inf_talus__abs_deb");
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.AbsFin) .HasColumnName("inf_talus__abs_fin");
            modelBuilder.Entity<InfTalus>().Property(t => t.Hauteur) .HasColumnName("inf_talus__hauteur");
            modelBuilder.Entity<InfTalus>().Property(t => t.Id) .HasColumnName("inf_talus__id");
            modelBuilder.Entity<InfTalus>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.InfCodeTalusId) .HasColumnName("inf_cd_talus__id");
            modelBuilder.Entity<InfTalus>().Property(t => t.InfCodeTalusId).IsRequired();
            modelBuilder.Entity<InfTalus>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfTalus>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTalus>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTalus>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTpc>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTpcs);
            modelBuilder.Entity<InfTpc>().HasRequired<InfCodeTpc>(c => c.InfCodeTpc).WithMany(t => t.InfTpcs);
            modelBuilder.Entity<InfTpc>().ToTable("inf_tpc", "inf");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsDeb) .HasColumnName("inf_tpc__abs_deb");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsFin) .HasColumnName("inf_tpc__abs_fin");
            modelBuilder.Entity<InfTpc>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.Id) .HasColumnName("inf_tpc__id");
            modelBuilder.Entity<InfTpc>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.InfCodeTpcId) .HasColumnName("inf_cd_tpc__id");
            modelBuilder.Entity<InfTpc>().Property(t => t.InfCodeTpcId).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfTpc>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTpc>().Property(t => t.Largeur) .HasColumnName("inf_tpc__largeur");
            modelBuilder.Entity<InfTpc>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTpc>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfTrDec>().HasRequired<InfChaussee>(c => c.InfChaussee).WithMany(t => t.InfTrDecs);
            modelBuilder.Entity<InfTrDec>().HasRequired<InfCodeDec>(c => c.InfCodeDec).WithMany(t => t.InfTrDecs);
            modelBuilder.Entity<InfTrDec>().ToTable("inf_tr_dec", "inf");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsDeb) .HasColumnName("inf_tr_dec__abs_deb");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsDeb).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsFin) .HasColumnName("inf_tr_dec__abs_fin");
            modelBuilder.Entity<InfTrDec>().Property(t => t.AbsFin).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id) .HasColumnName("inf_tr_dec__id");
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfCodeDecId) .HasColumnName("inf_cd_dec__id");
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfCodeDecId).IsRequired();
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfChausseeId) .HasColumnName("inf_chaussee__id");
            modelBuilder.Entity<InfTrDec>().Property(t => t.InfChausseeId).IsRequired();
            modelBuilder.Entity<InfTrDec>().HasKey(t => t.Id);
            modelBuilder.Entity<InfTrDec>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeAire>().ToTable("inf_cd_aire", "inf");
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Code) .HasColumnName("inf_cd_aire__code");
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Id) .HasColumnName("inf_cd_aire__id");
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Libelle) .HasColumnName("inf_cd_aire__libelle");
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeAire>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeAire>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeLiaison>().ToTable("inf_cd_liaison", "inf");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code) .HasColumnName("inf_cd_liaison__code");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Couleur) .HasColumnName("inf_cd_liaison__couleur");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Couleur).HasMaxLength(15);
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id) .HasColumnName("inf_cd_liaison__id");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Libelle) .HasColumnName("inf_cd_liaison__libelle");
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeLiaison>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeLiaison>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePlace>().ToTable("inf_cd_place", "inf");
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Code) .HasColumnName("inf_cd_place__code");
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Id) .HasColumnName("inf_cd_place__id");
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Libelle) .HasColumnName("inf_cd_place__libelle");
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodePlace>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePlace>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodePrestataire>().ToTable("inf_cd_prestataire", "inf");
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Code) .HasColumnName("inf_cd_prestataire__code");
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Id) .HasColumnName("inf_cd_prestataire__id");
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Libelle) .HasColumnName("inf_cd_prestataire__libelle");
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodePrestataire>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodePrestataire>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<InfCodeService>().ToTable("inf_cd_service", "inf");
            modelBuilder.Entity<InfCodeService>().Property(t => t.Code) .HasColumnName("inf_cd_service__code");
            modelBuilder.Entity<InfCodeService>().Property(t => t.Code).IsRequired();
            modelBuilder.Entity<InfCodeService>().Property(t => t.Code).HasMaxLength(50);
            modelBuilder.Entity<InfCodeService>().Property(t => t.Id) .HasColumnName("inf_cd_service__id");
            modelBuilder.Entity<InfCodeService>().Property(t => t.Id).IsRequired();
            modelBuilder.Entity<InfCodeService>().Property(t => t.Libelle) .HasColumnName("inf_cd_service__libelle");
            modelBuilder.Entity<InfCodeService>().Property(t => t.Libelle).HasMaxLength(200);
            modelBuilder.Entity<InfCodeService>().HasKey(t => t.Id);
            modelBuilder.Entity<InfCodeService>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }



    }
}

