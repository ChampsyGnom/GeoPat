using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Occupation")]
    public class InfOccupation : IInfOccupation
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code occupant")]
        public virtual InfCodeOccupant InfCodeOccupant
        {
            get;
            set;
        }
        [DisplayName("Code occupation")]
        public virtual InfCodeOccupation InfCodeOccupation
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
        [DisplayName("Date FG")]
        public Nullable<DateTime> DateFg
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
        [DisplayName("Fin")]
        public Nullable<Int64> AbsFin
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
        [DisplayName("Identifiant code occupant")]
        public Int64 InfCodeOccupantId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupation")]
        public Int64 InfCodeOccupationId
        {
            get;
            set;
        }
        [DisplayName("Traversé")]
        public Nullable<Boolean> Traverse
        {
            get;
            set;
        }


    }
}
