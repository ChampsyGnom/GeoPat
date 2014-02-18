using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code point singulier")]
    public class InfCodePtSing : IInfCodePtSing
    {
    	
        [DisplayName("Point singulier")]
        public virtual ICollection<InfPtSing> InfPtSings
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
        [DisplayName("Libelle")]
        public String Libelle
        {
            get;
            set;
        }


    }
}
