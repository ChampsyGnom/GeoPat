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
        [Column("MAP",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String Map { get; set; }
        
        [Description("Titre")]
        [Column("TITRE",Order=4)]
        [Required()]
        [MaxLength(50)] 
        public String Titre { get; set; }
        
        [Description("Type objet")]
        [Column("OBJTYPE",Order=5)]
        public Nullable<Int64> Objtype { get; set; }
        
        [Description("Rang")]
        [Column("RANG",Order=6)]
        public Nullable<Int64> Rang { get; set; }
        
        [Description("Order")]
        [Column("MAP_ORDER",Order=7)]
        [Required()]
        public Int64 MapOrder { get; set; }
        
        [Description("Schéma")]
        [Column("OWNER",Order=8)]
        [Required()]
        [MaxLength(50)] 
        public String Owner { get; set; }
        
        [Description("Est gécodé")]
        [Column("ISGEOCODE",Order=9)]
        public Nullable<Int64> Isgeocode { get; set; }
        
        [Description("Chemin")]
        [Column("CHEMIN",Order=10)]
        [Required()]
        [MaxLength(254)] 
        public String Chemin { get; set; }
        
    }
}
