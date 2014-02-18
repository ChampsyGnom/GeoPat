using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Accident")]
    public class InfAccident : IInfAccident
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Année")]
        public Int64 Annee
        {
            get;
            set;
        }
        [DisplayName("Début")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [DisplayName("Identifiant")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Mois")]
        public Int64 Mois
        {
            get;
            set;
        }
        [DisplayName("Nb accident")]
        public Nullable<Int64> Nb
        {
            get;
            set;
        }
        [DisplayName("Nb accident par mois")]
        public Nullable<Int64> NbMois
        {
            get;
            set;
        }


    }
}
