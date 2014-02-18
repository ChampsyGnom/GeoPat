using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code voie")]
    public class InfCodeVoie : IInfCodeVoie
    {
    	
        [DisplayName("Pavé voie")]
        public virtual ICollection<InfPaveVoie> InfPaveVoies
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
        [DisplayName("Identifiant")]
        public Int64 Id
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
        [DisplayName("Position")]
        public Int64 Position
        {
            get;
            set;
        }
        [DisplayName("Roulable")]
        public Boolean Roulable
        {
            get;
            set;
        }


    }
}
