using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MAP",Schema="MAPINFO")]
    public partial class MapinfoTbMap
    {
        public virtual MapinfoTbGroupe MapinfoTbGroupe {get;set;}
        
        public virtual ICollection<MapinfoTbMapCfg> MapinfoTbMapCfgs { get; set; }
        
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
        public String Map { get; set; }
        
        [Description("Titre")]
        [Column("TB_MAP__TITRE",Order=4)]
        [Required()]
        [MaxLength(50)] 
        public String Titre { get; set; }
        
        [Description("Type objet")]
        [Column("TB_MAP__OBJTYPE",Order=5)]
        public Nullable<Int64> Objtype { get; set; }
        
        [Description("Rang")]
        [Column("TB_MAP__RANG",Order=6)]
        public Nullable<Int64> Rang { get; set; }
        
        [Description("Order")]
        [Column("TB_MAP__MAP_ORDER",Order=7)]
        [Required()]
        public Int64 MapOrder { get; set; }
        
        [Description("Schéma")]
        [Column("TB_MAP__OWNER",Order=8)]
        [Required()]
        [MaxLength(50)] 
        public String Owner { get; set; }
        
        [Description("Est gécodé")]
        [Column("TB_MAP__ISGEOCODE",Order=9)]
        public Nullable<Int64> Isgeocode { get; set; }
        
        [Description("Chemin")]
        [Column("TB_MAP__CHEMIN",Order=10)]
        [Required()]
        [MaxLength(254)] 
        public String Chemin { get; set; }
        
    }
}
