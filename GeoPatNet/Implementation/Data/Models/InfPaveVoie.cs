using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Pavé voie")]
    public class InfPaveVoie : IInfPaveVoie
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code voie")]
        public virtual InfCodeVoie InfCodeVoie
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        public DateTime DateMs
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
        public Int64 AbsFin
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
        [DisplayName("Identifiant code voie")]
        public Int64 InfCodeVoieId
        {
            get;
            set;
        }
        [DisplayName("Largeur")]
        public Double Largeur
        {
            get;
            set;
        }


    }
}
