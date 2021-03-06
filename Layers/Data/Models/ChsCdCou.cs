using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_COU_CHS",Schema="CHS")]
    public partial class ChsCdCou
    {
        [Key]
        [Description("Couche")]
        [Column("COUCHE",Order=0)]
        [Required()]
        [MaxLength(14)] 
        public String Couche { get; set; }
        
        [Description("Position")]
        [Column("POSIT",Order=1)]
        [Required()]
        public Int64 Posit { get; set; }
        
        [Description("Couleur")]
        [Column("COULEUR",Order=2)]
        [MaxLength(16)] 
        public String Couleur { get; set; }
        
    }
}
