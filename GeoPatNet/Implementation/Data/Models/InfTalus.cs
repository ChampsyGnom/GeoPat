using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Talus")]
    public class InfTalus : IInfTalus
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code talus")]
        public virtual InfCodeTalus InfCodeTalus
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
        [DisplayName("Hauteur")]
        public Nullable<Double> Hauteur
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
        [DisplayName("Identifiant chaussée")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code talus")]
        public Int64 InfCodeTalusId
        {
            get;
            set;
        }


    }
}
