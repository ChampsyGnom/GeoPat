using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_TEMPLATE",Schema="MAPINFO")]
    public partial class MapinfoTbTemplate
    {
        public virtual MapinfoTbModele MapinfoTbModele {get;set;}
        
        public virtual ICollection<MapinfoTbTemplateCfg> MapinfoTbTemplateCfgs { get; set; }
        
        public virtual ICollection<MapinfoTbGroupe> MapinfoTbGroupes { get; set; }
        
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
        public String Tpl { get; set; }
        
        [Description("Titre")]
        [Column("TB_TEMPLATE__TITRE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Titre { get; set; }
        
        [Description("Rang")]
        [Column("TB_TEMPLATE__RANG",Order=3)]
        [Required()]
        public Int64 Rang { get; set; }
        
        [Description("Chemin")]
        [Column("TB_TEMPLATE__CHEMIN",Order=4)]
        [MaxLength(254)] 
        public String Chemin { get; set; }
        
        [Description("Est géocodé")]
        [Column("TB_TEMPLATE__ISGEOCODE",Order=5)]
        public Nullable<Int64> Isgeocode { get; set; }
        
    }
}
