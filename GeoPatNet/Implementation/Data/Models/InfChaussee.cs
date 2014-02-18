using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Chaussée")]
    public class InfChaussee : IInfChaussee
    {
    	
        [DisplayName("Accident")]
        public virtual ICollection<InfAccident> InfAccidents
        {
            get;
            set;
        }
        [DisplayName("Aménagement")]
        public virtual ICollection<InfAmenagement> InfAmenagements
        {
            get;
            set;
        }
        [DisplayName("Ancien repérage")]
        public virtual ICollection<InfPrOld> InfPrOlds
        {
            get;
            set;
        }
        [DisplayName("Bifurcation")]
        public virtual ICollection<InfBifurcation> InfBifurcations
        {
            get;
            set;
        }
        [DisplayName("Bretelle")]
        public virtual ICollection<InfBretelle> InfBretelles
        {
            get;
            set;
        }
        [DisplayName("Climat")]
        public virtual ICollection<InfClimat> InfClimats
        {
            get;
            set;
        }
        [DisplayName("Eclairage")]
        public virtual ICollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Gare")]
        public virtual ICollection<InfGare> InfGares
        {
            get;
            set;
        }
        [DisplayName("Occupation")]
        public virtual ICollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Pavé voie")]
        public virtual ICollection<InfPaveVoie> InfPaveVoies
        {
            get;
            set;
        }
        [DisplayName("PK Chantier")]
        public virtual ICollection<InfPk> InfPks
        {
            get;
            set;
        }
        [DisplayName("Point singulier")]
        public virtual ICollection<InfPtSing> InfPtSings
        {
            get;
            set;
        }
        [DisplayName("Répartition trafic")]
        public virtual ICollection<InfRepartitionTrafic> InfRepartitionTrafics
        {
            get;
            set;
        }
        [DisplayName("Repère")]
        public virtual ICollection<InfRepere> InfReperes
        {
            get;
            set;
        }
        [DisplayName("Section trafic")]
        public virtual ICollection<InfSectionTrafic> InfSectionTrafics
        {
            get;
            set;
        }
        [DisplayName("Sécurité")]
        public virtual ICollection<InfSecurite> InfSecurites
        {
            get;
            set;
        }
        [DisplayName("Sensibilité")]
        public virtual ICollection<InfSensible> InfSensibles
        {
            get;
            set;
        }
        [DisplayName("Talus")]
        public virtual ICollection<InfTalus> InfTaluss
        {
            get;
            set;
        }
        [DisplayName("Terre plein central")]
        public virtual ICollection<InfTpc> InfTpcs
        {
            get;
            set;
        }
        [DisplayName("Tronçons découpage")]
        public virtual ICollection<InfTrDec> InfTrDecs
        {
            get;
            set;
        }
        [DisplayName("Liaison")]
        public virtual InfLiaison InfLiaison
        {
            get;
            set;
        }
        [DisplayName("Code")]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant liaison")]
        public Int64 InfLiaisonId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
