using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_EQP",Schema="EQP")]
    public partial class EqpCdType
    {
        [Key]
        [Description("Type d'équipement")]
        [Column("TYPE_EQUIP",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String TypeEquip { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
