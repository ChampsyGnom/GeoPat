using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MODELE",Schema="MAPINFO")]
    public partial class MapinfoTbModele
    {
        public virtual ICollection<MapinfoTbModeleCfg> MapinfoTbModeleCfgs { get; set; }
        
        public virtual ICollection<MapinfoTbTemplate> MapinfoTbTemplates { get; set; }
        
        [Key]
        [Description("Nom")]
        [Column("TB_MODELE__MODELE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Modele { get; set; }
        
        [Description("Ordre")]
        [Column("TB_MODELE__ORDRE",Order=1)]
        public Nullable<Int64> Ordre { get; set; }
        
        [Description("Couche MAPINFO")]
        [Column("TB_MODELE__LAYER_NAME",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String LayerName { get; set; }
        
        [Description("Fichier REF")]
        [Column("TB_MODELE__PATH",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Path { get; set; }
        
        [Description("Type de modèle")]
        [Column("TB_MODELE__TYPE_MODELE",Order=4)]
        [Required()]
        public Int64 TypeModele { get; set; }
        
    }
}
