using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_ANA_THEMA",Schema="MAPINFO")]
    public partial class MapinfoTbAnaThema
    {
        [Key]
        [Description("Nom User")]
        [Column("USERCODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Usercode { get; set; }
        
        [Key]
        [Description("Carte")]
        [Column("MAP",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String Map { get; set; }
        
        [Key]
        [Description("Nom Modele")]
        [Column("MODELE",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String Modele { get; set; }
        
        [Key]
        [Description("Code Prp")]
        [Column("CODE_PRP",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String CodePrp { get; set; }
        
        [Description("Valeur Prp")]
        [Column("VAL_PRP",Order=4)]
        [MaxLength(254)] 
        public String ValPrp { get; set; }
        
    }
}
