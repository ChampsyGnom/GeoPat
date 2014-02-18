using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Eclairage")]
    public class InfEclairage : IInfEclairage
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code éclairage")]
        public virtual InfCodeEclairage InfCodeEclairage
        {
            get;
            set;
        }
        [DisplayName("Code position")]
        public virtual InfCodePosit InfCodePosit
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
        [DisplayName("Identifiant code éclairage")]
        public Int64 InfCodeEclairageId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code position")]
        public Int64 InfCodePositId
        {
            get;
            set;
        }


    }
}
