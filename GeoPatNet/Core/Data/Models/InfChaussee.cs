using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Chaussée")]
    [TableName("INF_CHAUSSEE")]
    [SchemaName("INF")]
    public class InfChaussee 
    {
    	
        [DisplayName("Accidents")]
        public virtual ObservableCollection<InfAccident> InfAccidents
        {
            get;
            set;
        }
        [DisplayName("Airess")]
        public virtual ObservableCollection<InfAire> InfAires
        {
            get;
            set;
        }
        [DisplayName("Aménagements")]
        public virtual ObservableCollection<InfAmenagement> InfAmenagements
        {
            get;
            set;
        }
        [DisplayName("Ancien repérages")]
        public virtual ObservableCollection<InfPrOld> InfPrOlds
        {
            get;
            set;
        }
        [DisplayName("Bifurcations")]
        public virtual ObservableCollection<InfBifurcation> InfBifurcations
        {
            get;
            set;
        }
        [DisplayName("Bretelles")]
        public virtual ObservableCollection<InfBretelle> InfBretelles
        {
            get;
            set;
        }
        [DisplayName("Climats")]
        public virtual ObservableCollection<InfClimat> InfClimats
        {
            get;
            set;
        }
        [DisplayName("Eclairages")]
        public virtual ObservableCollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Gares")]
        public virtual ObservableCollection<InfGare> InfGares
        {
            get;
            set;
        }
        [DisplayName("Occupations")]
        public virtual ObservableCollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Pavé voies")]
        public virtual ObservableCollection<InfPaveVoie> InfPaveVoies
        {
            get;
            set;
        }
        [DisplayName("PK Chantiers")]
        public virtual ObservableCollection<InfPk> InfPks
        {
            get;
            set;
        }
        [DisplayName("Point singuliers")]
        public virtual ObservableCollection<InfPtSing> InfPtSings
        {
            get;
            set;
        }
        [DisplayName("Répartition trafics")]
        public virtual ObservableCollection<InfRepartitionTrafic> InfRepartitionTrafics
        {
            get;
            set;
        }
        [DisplayName("Repères")]
        public virtual ObservableCollection<InfRepere> InfReperes
        {
            get;
            set;
        }
        [DisplayName("Section trafics")]
        public virtual ObservableCollection<InfSectionTrafic> InfSectionTrafics
        {
            get;
            set;
        }
        [DisplayName("Sécurités")]
        public virtual ObservableCollection<InfSecurite> InfSecurites
        {
            get;
            set;
        }
        [DisplayName("Sensibilités")]
        public virtual ObservableCollection<InfSensible> InfSensibles
        {
            get;
            set;
        }
        [DisplayName("Taluss")]
        public virtual ObservableCollection<InfTalus> InfTaluss
        {
            get;
            set;
        }
        [DisplayName("Terre plein centrals")]
        public virtual ObservableCollection<InfTpc> InfTpcs
        {
            get;
            set;
        }
        [DisplayName("Tronçons découpages")]
        public virtual ObservableCollection<InfTrDec> InfTrDecs
        {
            get;
            set;
        }
        [DisplayName("Liaison")]
        [ColumnName("INF_LIAISON__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_LIAISON__CHAUSSEE_INF",null)]
        [UniqueKey("INF_CHAUSSEE_UK_REF")]
        public virtual InfLiaison InfLiaison
        {
            get;
            set;
        }
        [DisplayName("Aboutissant")]
        [ColumnName("INF_CHAUSSEE__ABOUT")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String About
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CHAUSSEE__CODE")]
        [UniqueKey("INF_CHAUSSEE_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [DisplayName("Debut")]
        [ColumnName("INF_CHAUSSEE__ABS_DEB")]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_CHAUSSEE__ABS_FIN")]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [AllowNull(false)]
        public Int64 AbsFin
        {
            get;
            set;
        }
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        [DisplayName("Géométrie")]
        [ColumnName("INF_CHAUSSEE__GEOM")]
        public String Geom
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [PrimaryKey("INF_CHAUSSEE_PK")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_ACCIDENT","JOIN_o914")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_AIRE","JOIN_o954")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_AMENAGEMENT","JOIN_o916")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PR_OLD","JOIN_o918")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_BIFURCATION","JOIN_o920")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_BRETELLE","JOIN_o922")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_CLIMAT","JOIN_o924")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_ECLAIRAGE","JOIN_o926")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_GARE","JOIN_o928")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_OCCUPATION","JOIN_o930")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PAVE_VOIE","JOIN_o932")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PK","JOIN_o934")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PT_SING","JOIN_o936")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_REPARTITION_TRAFIC","JOIN_o938")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_REPERE","JOIN_o940")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SECTION_TRAFIC","JOIN_o942")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SECURITE","JOIN_o944")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SENSIBLE","JOIN_o946")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TALUS","JOIN_o948")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TPC","JOIN_o950")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TR_DEC","JOIN_o952")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant liaison")]
        [ColumnName("INF_LIAISON__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfLiaisonId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CHAUSSEE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Tenant")]
        [ColumnName("INF_CHAUSSEE__TENANT")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Tenant
        {
            get;
            set;
        }


		public InfChaussee ()
		{
            this.InfAccidents = new ObservableCollection<InfAccident>();
            this.InfAires = new ObservableCollection<InfAire>();
            this.InfAmenagements = new ObservableCollection<InfAmenagement>();
            this.InfPrOlds = new ObservableCollection<InfPrOld>();
            this.InfBifurcations = new ObservableCollection<InfBifurcation>();
            this.InfBretelles = new ObservableCollection<InfBretelle>();
            this.InfClimats = new ObservableCollection<InfClimat>();
            this.InfEclairages = new ObservableCollection<InfEclairage>();
            this.InfGares = new ObservableCollection<InfGare>();
            this.InfOccupations = new ObservableCollection<InfOccupation>();
            this.InfPaveVoies = new ObservableCollection<InfPaveVoie>();
            this.InfPks = new ObservableCollection<InfPk>();
            this.InfPtSings = new ObservableCollection<InfPtSing>();
            this.InfRepartitionTrafics = new ObservableCollection<InfRepartitionTrafic>();
            this.InfReperes = new ObservableCollection<InfRepere>();
            this.InfSectionTrafics = new ObservableCollection<InfSectionTrafic>();
            this.InfSecurites = new ObservableCollection<InfSecurite>();
            this.InfSensibles = new ObservableCollection<InfSensible>();
            this.InfTaluss = new ObservableCollection<InfTalus>();
            this.InfTpcs = new ObservableCollection<InfTpc>();
            this.InfTrDecs = new ObservableCollection<InfTrDec>();
		}

    }
}
