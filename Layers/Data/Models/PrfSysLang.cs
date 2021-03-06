using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SYS_LANG",Schema="PRF")]
    public partial class PrfSysLang
    {
        [Key]
        [Description("CODE_APP")]
        [Column("CODE_APP",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String CodeApp { get; set; }
        
        [Key]
        [Description("CODE_PRP")]
        [Column("CODE_PRP",Order=1)]
        [Required()]
        [MaxLength(1000)] 
        public String CodePrp { get; set; }
        
        [Description("VAL_PRP")]
        [Column("VAL_PRP",Order=2)]
        [MaxLength(1000)] 
        public String ValPrp { get; set; }
        
        [Description("SORT_TRAD")]
        [Column("SORT_TRAD",Order=3)]
        public Nullable<Int64> SortTrad { get; set; }
        
    }
}
