using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Liaison")]
    public class InfLiaison : IInfLiaison
    {
    	
        [DisplayName("Chaussée")]
        public virtual ICollection<InfChaussee> InfChaussees
        {
            get;
            set;
        }
        [DisplayName("Type liaison")]
        public virtual InfCodeLiaison InfCodeLiaison
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
        [DisplayName("Identifiant type liaison")]
        public Int64 InfCodeLiaisonId
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
