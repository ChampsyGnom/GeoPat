using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Gare")]
    public class InfGare : IInfGare
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code gare")]
        public virtual InfCodeGare InfCodeGare
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
        [DisplayName("Identifiant code gare")]
        public Int64 InfCodeGareId
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
        [DisplayName("Nb de voie de sortie")]
        public Nullable<Int64> NbSortie
        {
            get;
            set;
        }
        [DisplayName("Nb de voie d'entrée")]
        public Nullable<Int64> NbEntree
        {
            get;
            set;
        }
        [DisplayName("Nb de voie mixte")]
        public Nullable<Int64> NbMixte
        {
            get;
            set;
        }
        [DisplayName("Nb de voie TSA")]
        public Nullable<Int64> NbTsa
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
