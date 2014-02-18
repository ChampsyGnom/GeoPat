using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Sécurité")]
    public class InfSecurite : IInfSecurite
    {
    	
        [DisplayName("Chaussée")]
        public virtual InfChaussee InfChaussee
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
        [DisplayName("Code sécurité")]
        public virtual InfCodeSecurite InfCodeSecurite
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
        [DisplayName("Identifiant code position")]
        public Int64 InfCodePositId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code sécurité")]
        public Int64 InfCodeSecuriteId
        {
            get;
            set;
        }


    }
}
