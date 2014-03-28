using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRODUIT_SH_EQP",Schema="EQP")]
    public partial class EqpCdProduitSh
    {
        public virtual ICollection<EqpDscSh> EqpDscShs { get; set; }
        
        [Key]
        [Description("Produit")]
        [Column("CD_PRODUIT_SH_EQP__PRODUIT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Produit { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_PRODUIT_SH_EQP__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_PRODUIT_SH_EQP__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
