using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_TEMPLATE_CFG",Schema="MAPINFO")]
    public partial class MapinfoTbTemplateCfg
    {
        [Key]
        [Description("Nom")]
        [Column("TB_MODELE__MODELE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String TbModeleModele { get; set; }
        
        [Key]
        [Description("Template")]
        [Column("TB_TEMPLATE__TPL",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String TbTemplateTpl { get; set; }
        
        [Key]
        [Description("Utilisateur")]
        [Column("USERCODE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Usercode { get; set; }
        
        [Key]
        [Description("Propriétée")]
        [Column("CODE_PRP",Order=3)]
        [Required()]
        [MaxLength(20)] 
        public String CodePrp { get; set; }
        
        [Description("Valeur")]
        [Column("VAL_PRP",Order=4)]
        [Required()]
        [MaxLength(254)] 
        public String ValPrp { get; set; }
        
    }
}
