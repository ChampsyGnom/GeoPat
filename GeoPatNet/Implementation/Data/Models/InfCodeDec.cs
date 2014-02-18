using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Code découpage")]
    public class InfCodeDec : IInfCodeDec
    {
    	
        [DisplayName("Tronçons découpage")]
        public virtual ICollection<InfTrDec> InfTrDecs
        {
            get;
            set;
        }
        [DisplayName("Famille découpage")]
        public virtual InfFamDec InfFamDec
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
        [DisplayName("Identifiant famille découpage")]
        public Int64 InfFamDecId
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
