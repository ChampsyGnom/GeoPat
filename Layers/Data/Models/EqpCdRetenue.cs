using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_RETENUE_EQP",Schema="EQP")]
    public partial class EqpCdRetenue
    {
        [Key]
        [Description("Matériaux")]
        [Column("CD_MATERIAU_EQP__MATERIAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdMateriauEqpMateriaux { get; set; }
        
        [Key]
        [Description("Type de Dispositif")]
        [Column("DISPOSITIF",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Dispositif { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("GARANTIE",Order=3)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("DVT",Order=4)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
