using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Bifurcation")]
    public class InfBifurcation : IInfBifurcation
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code bifurcation")]
        public virtual InfCodeBifurcation InfCodeBifurcation
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        public Nullable<DateTime> DateMs
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
        [DisplayName("Identifiant code bifurcation")]
        public Int64 InfCodeBifurcationId
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        public String Nom
        {
            get;
            set;
        }


    }
}
