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
        [Key]
        [Description("Nom")]
        [Column("TB_MODELE__MODELE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String TbModeleModele { get; set; }
        
        [Key]
        [Description("Template")]
        [Column("TPL",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String Tpl { get; set; }
        
        [Description("Titre")]
        [Column("TITRE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Titre { get; set; }
        
        [Description("Rang")]
        [Column("RANG",Order=3)]
        [Required()]
        public Int64 Rang { get; set; }
        
        [Description("Chemin")]
        [Column("CHEMIN",Order=4)]
        [MaxLength(254)] 
        public String Chemin { get; set; }
        
        [Description("Est géocodé")]
        [Column("ISGEOCODE",Order=5)]
        public Nullable<Int64> Isgeocode { get; set; }
        
    }
}
