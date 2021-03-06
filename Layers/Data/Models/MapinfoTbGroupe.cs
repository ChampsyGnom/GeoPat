using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_GROUPE",Schema="MAPINFO")]
    public partial class MapinfoTbGroupe
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
        [Column("GROUPE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Groupe { get; set; }
        
        [Description("Titre")]
        [Column("TITRE",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String Titre { get; set; }
        
        [Description("Rang")]
        [Column("RANG",Order=4)]
        [Required()]
        public Int64 Rang { get; set; }
        
        [Description("Chemin")]
        [Column("CHEMIN",Order=5)]
        [MaxLength(254)] 
        public String Chemin { get; set; }
        
        [Description("Afficher")]
        [Column("BOARDVISIBLE",Order=6)]
        public Nullable<Int64> Boardvisible { get; set; }
        
    }
}
