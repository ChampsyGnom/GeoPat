using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code position")]
    public class InfCodePosit : IInfCodePosit
    {
    	
        [DisplayName("Eclairage")]
        public virtual ICollection<InfEclairage> InfEclairages
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
        [Browsable(false)]
        [DisplayName("Identifiant")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Ordre")]
        public Nullable<Int64> Ordre
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


    }
}
