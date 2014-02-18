using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code aménagement")]
    public class InfCodeAmenagement : IInfCodeAmenagement
    {
    	
        [DisplayName("Aménagement")]
        public virtual ICollection<InfAmenagement> InfAmenagements
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
        [DisplayName("Libellé")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
