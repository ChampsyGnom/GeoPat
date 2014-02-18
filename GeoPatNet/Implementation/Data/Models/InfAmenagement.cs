using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Aménagement")]
    public class InfAmenagement : IInfAmenagement
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code aménagement")]
        public virtual InfCodeAmenagement InfCodeAmenagement
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
        [DisplayName("Coût")]
        public Nullable<Int64> Cout
        {
            get;
            set;
        }
        [DisplayName("Date début")]
        public DateTime DateDeb
        {
            get;
            set;
        }
        [DisplayName("Date fin")]
        public Nullable<DateTime> DateFin
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
        [DisplayName("Identifiant code aménagement")]
        public Int64 InfCodeAmenagementId
        {
            get;
            set;
        }


    }
}
