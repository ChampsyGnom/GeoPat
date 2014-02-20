using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Chaussée")]
    [TableName("INF_CHAUSSEE")]
    [SchemaName("INF")]
    public class InfChaussee : IInfChaussee
    {
    	
        [DisplayName("Accidents")]
        public virtual ICollection<InfAccident> InfAccidents
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
        public virtual InfLiaison InfLiaison
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
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [PrimaryKey("INF_CHAUSSEE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant liaison")]
        [ColumnName("INF_LIAISON__ID")]
        [ForeignKey("INF_LIAISON__CHAUSSEE_INF","JOIN_o793")]
        [UniqueKey("INF_CHAUSSEE_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
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


    }
}
