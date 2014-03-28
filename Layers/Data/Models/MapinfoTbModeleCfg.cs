using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MODELE_CFG",Schema="MAPINFO")]
    public partial class MapinfoTbModeleCfg
    {
        public virtual MapinfoTbModele MapinfoTbModele {get;set;}
        
        [Key]
        [Description("Nom")]
        [Column("TB_MODELE__MODELE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String TbModeleModele { get; set; }
        
        [Key]
        [Description("Utilisateur")]
        [Column("TB_MODELE_CFG__USERCODE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String Usercode { get; set; }
        
        [Description("Propriété")]
        [Column("TB_MODELE_CFG__CODE_PRP",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String CodePrp { get; set; }
        
        [Description("Valeur")]
        [Column("TB_MODELE_CFG__VAL_PRP",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String ValPrp { get; set; }
        
    }
}
