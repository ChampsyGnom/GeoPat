using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Chaussée")]
    [TableName("INF_CHAUSSEE")]
    [SchemaName("INF")]
    public class InfChaussee 
    {
    	
        [DisplayName("Accidents")]
        public virtual ICollection<InfAccident> InfAccidents
        {
            get;
            set;
        }
        [DisplayName("Airess")]
        public virtual ICollection<InfAire> InfAires
        {
            get;
            set;
        }
        [DisplayName("Aménagements")]
        public virtual ICollection<InfAmenagement> InfAmenagements
        {
            get;
            set;
        }
        [DisplayName("Ancien repérages")]
        public virtual ICollection<InfPrOld> InfPrOlds
        {
            get;
            set;
        }
        [DisplayName("Bifurcations")]
        public virtual ICollection<InfBifurcation> InfBifurcations
        {
            get;
            set;
        }
        [DisplayName("Bretelles")]
        public virtual ICollection<InfBretelle> InfBretelles
        {
            get;
            set;
        }
        [DisplayName("Climats")]
        public virtual ICollection<InfClimat> InfClimats
        {
            get;
            set;
        }
        [DisplayName("Eclairages")]
        public virtual ICollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Gares")]
        public virtual ICollection<InfGare> InfGares
        {
            get;
            set;
        }
        [DisplayName("Occupations")]
        public virtual ICollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Pavé voies")]
        public virtual ICollection<InfPaveVoie> InfPaveVoies
        {
            get;
            set;
        }
        [DisplayName("PK Chantiers")]
        public virtual ICollection<InfPk> InfPks
        {
            get;
            set;
        }
        [DisplayName("Point singuliers")]
        public virtual ICollection<InfPtSing> InfPtSings
        {
            get;
            set;
        }
        [DisplayName("Répartition trafics")]
        public virtual ICollection<InfRepartitionTrafic> InfRepartitionTrafics
        {
            get;
            set;
        }
        [DisplayName("Repères")]
        public virtual ICollection<InfRepere> InfReperes
        {
            get;
            set;
        }
        [DisplayName("Section trafics")]
        public virtual ICollection<InfSectionTrafic> InfSectionTrafics
        {
            get;
            set;
        }
        [DisplayName("Sécurités")]
        public virtual ICollection<InfSecurite> InfSecurites
        {
            get;
            set;
        }
        [DisplayName("Sensibilités")]
        public virtual ICollection<InfSensible> InfSensibles
        {
            get;
            set;
        }
        [DisplayName("Taluss")]
        public virtual ICollection<InfTalus> InfTaluss
        {
            get;
            set;
        }
        [DisplayName("Terre plein centrals")]
        public virtual ICollection<InfTpc> InfTpcs
        {
            get;
            set;
        }
        [DisplayName("Tronçons découpages")]
        public virtual ICollection<InfTrDec> InfTrDecs
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
        [RulePr("ID")]
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
        [RulePr("ID")]
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
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_ACCIDENT","JOIN_o831")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_AIRE","JOIN_o871")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_AMENAGEMENT","JOIN_o833")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PR_OLD","JOIN_o835")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_BIFURCATION","JOIN_o837")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_BRETELLE","JOIN_o839")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_CLIMAT","JOIN_o841")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_ECLAIRAGE","JOIN_o843")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_GARE","JOIN_o845")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_OCCUPATION","JOIN_o847")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PAVE_VOIE","JOIN_o849")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PK","JOIN_o851")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_PT_SING","JOIN_o853")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_REPARTITION_TRAFIC","JOIN_o855")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_REPERE","JOIN_o857")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SECTION_TRAFIC","JOIN_o859")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SECURITE","JOIN_o861")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_SENSIBLE","JOIN_o863")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TALUS","JOIN_o865")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TPC","JOIN_o867")]
        [ForeignKeyAttribute("INF_CHAUSSEE__INF_TR_DEC","JOIN_o869")]
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


    }
}
