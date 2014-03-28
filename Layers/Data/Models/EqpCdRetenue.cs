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
        public virtual EqpCdMateriau EqpCdMateriau {get;set;}
        
        public virtual ICollection<EqpDscEs> EqpDscEss { get; set; }
        
        [Key]
        [Description("Matériaux")]
        [Column("CD_MATERIAU_EQP__MATERIAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdMateriauEqpMateriaux { get; set; }
        
        [Key]
        [Description("Type de Dispositif")]
        [Column("CD_RETENUE_EQP__DISPOSITIF",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Dispositif { get; set; }
        
        [Description("Libellé")]
        [Column("CD_RETENUE_EQP__LIBELLE",Order=2)]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_RETENUE_EQP__GARANTIE",Order=3)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_RETENUE_EQP__DVT",Order=4)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
