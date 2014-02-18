using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Section trafic")]
    public class InfSectionTrafic : IInfSectionTrafic
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Classe de trafic")]
        public virtual InfCodeTrafic InfCodeTrafic
        {
            get;
            set;
        }
        [DisplayName("Aboutissant")]
        public String About
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
        [DisplayName("Identifiant classe trafic")]
        public Int64 InfCodeTraficId
        {
            get;
            set;
        }
        [DisplayName("Tenant")]
        public String Tenant
        {
            get;
            set;
        }


    }
}
