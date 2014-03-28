using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MAP_CFG",Schema="MAPINFO")]
    public partial class MapinfoTbMapCfg
    {
        public virtual MapinfoTbMap MapinfoTbMap {get;set;}
        
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
        [Description("Groupe")]
        [Column("TB_GROUPE__GROUPE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String TbGroupeGroupe { get; set; }
        
        [Key]
        [Description("Carte")]
        [Column("TB_MAP__MAP",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String TbMapMap { get; set; }
        
        [Key]
        [Description("Utilisateur")]
        [Column("TB_MAP_CFG__USERCODE",Order=4)]
        [Required()]
        [MaxLength(50)] 
        public String Usercode { get; set; }
        
        [Key]
        [Description("Propriétée")]
        [Column("TB_MAP_CFG__CODE_PRP",Order=5)]
        [Required()]
        [MaxLength(50)] 
        public String CodePrp { get; set; }
        
        [Description("Valeur")]
        [Column("TB_MAP_CFG__VAL_PRP",Order=6)]
        [Required()]
        [MaxLength(254)] 
        public String ValPrp { get; set; }
        
    }
}
