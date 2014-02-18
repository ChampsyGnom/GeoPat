using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Point singulier")]
    public class InfPtSing : IInfPtSing
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code point singulier")]
        public virtual InfCodePtSing InfCodePtSing
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
        [DisplayName("Début")]
        public Int64 AbsDeb
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
        [DisplayName("Identifiant code point singulier")]
        public Int64 InfCodePtSingId
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
        [DisplayName("Nom d'usage")]
        public String Nom
        {
            get;
            set;
        }


    }
}
