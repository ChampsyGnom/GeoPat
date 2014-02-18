using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Bretelle")]
    public class InfBretelle : IInfBretelle
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
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
        [DisplayName("Extrémité")]
        public String Extremite
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
        [DisplayName("Libellé")]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("N° bretelle")]
        public String Num
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
        [DisplayName("Nom bretelle")]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Type")]
        public String Type
        {
            get;
            set;
        }


    }
}
