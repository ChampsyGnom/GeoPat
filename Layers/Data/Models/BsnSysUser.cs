using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SYS_USER_BSN",Schema="BSN")]
    public partial class BsnSysUser
    {
        [Key]
        [Description("SYS_USER_BSN__CODE_DBS")]
        [Column("SYS_USER_BSN__CODE_DBS",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String CodeDbs { get; set; }
        
        [Key]
        [Description("SYS_USER_BSN__CODE_TABLE")]
        [Column("SYS_USER_BSN__CODE_TABLE",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CodeTable { get; set; }
        
        [Key]
        [Description("SYS_USER_BSN__CODE_COLONNE")]
        [Column("SYS_USER_BSN__CODE_COLONNE",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String CodeColonne { get; set; }
        
        [Key]
        [Description("SYS_USER_BSN__NOM_USER")]
        [Column("SYS_USER_BSN__NOM_USER",Order=3)]
        [Required()]
        [MaxLength(150)] 
        public String NomUser { get; set; }
        
        [Key]
        [Description("SYS_USER_BSN__CODE_PRP")]
        [Column("SYS_USER_BSN__CODE_PRP",Order=4)]
        [Required()]
        [MaxLength(255)] 
        public String CodePrp { get; set; }
        
        [Description("SYS_USER_BSN__VAL_PRP")]
        [Column("SYS_USER_BSN__VAL_PRP",Order=5)]
        [Required()]
        [MaxLength(500)] 
        public String ValPrp { get; set; }
        
    }
}
