using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SYS_USER_WEB",Schema="WEB")]
    public partial class WebSysUser
    {
        [Key]
        [Description("Code dbs")]
        [Column("CODE_DBS",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String CodeDbs { get; set; }
        
        [Key]
        [Description("Code table")]
        [Column("CODE_TABLE",Order=1)]
        [Required()]
        [MaxLength(200)] 
        public String CodeTable { get; set; }
        
        [Key]
        [Description("Code colonne")]
        [Column("CODE_COLONNE",Order=2)]
        [Required()]
        [MaxLength(200)] 
        public String CodeColonne { get; set; }
        
        [Key]
        [Description("Code utilisateur")]
        [Column("NOM_USER",Order=3)]
        [Required()]
        [MaxLength(200)] 
        public String NomUser { get; set; }
        
        [Key]
        [Description("Code propriétée")]
        [Column("CODE_PRP",Order=4)]
        [Required()]
        [MaxLength(255)] 
        public String CodePrp { get; set; }
        
        [Description("Valeur propriétée")]
        [Column("VAL_PRP",Order=5)]
        [Required()]
        [MaxLength(255)] 
        public String ValPrp { get; set; }
        
    }
}
