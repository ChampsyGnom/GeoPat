using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SI_PRP",Schema="MAPINFO")]
    public partial class MapinfoSiPrp
    {
        [Key]
        [Description("Si Prp  Code Prp")]
        [Column("CODE_PRP",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String CodePrp { get; set; }
        
        [Key]
        [Description("Si Prp  Val Prp")]
        [Column("VAL_PRP",Order=1)]
        [Required()]
        [MaxLength(1024)] 
        public String ValPrp { get; set; }
        
    }
}
