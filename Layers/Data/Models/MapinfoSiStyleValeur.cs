using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SI_STYLE_VALEUR",Schema="MAPINFO")]
    public partial class MapinfoSiStyleValeur
    {
        [Key]
        [Description("Si Model  Nom Model")]
        [Column("SI_MODEL__NOM_MODEL",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String SiModelNomModel { get; set; }
        
        [Key]
        [Description("Si Zone  Nom Zone")]
        [Column("SI_ZONE__NOM_ZONE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String SiZoneNomZone { get; set; }
        
        [Key]
        [Description("Si Style Valeur  Valeur")]
        [Column("VALEUR",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String Valeur { get; set; }
        
        [Description("Si Style Valeur  Couleur")]
        [Column("COULEUR",Order=3)]
        [MaxLength(9)] 
        public String Couleur { get; set; }
        
        [Description("Si Style Valeur  Border")]
        [Column("BORDER",Order=4)]
        public Nullable<Int64> Border { get; set; }
        
        [Description("Si Style Valeur  Taille")]
        [Column("TAILLE",Order=5)]
        public Nullable<Int64> Taille { get; set; }
        
        [Description("Si Style Valeur  Representation")]
        [Column("REPRESENTATION",Order=6)]
        [MaxLength(20)] 
        public String Representation { get; set; }
        
        [Description("Si Style Valeur  Chemin")]
        [Column("CHEMIN",Order=7)]
        [MaxLength(1024)] 
        public String Chemin { get; set; }
        
        [Description("Si Style Valeur Font Name")]
        [Column("FONT_NAME",Order=8)]
        [MaxLength(50)] 
        public String FontName { get; set; }
        
        [Description("Si Style Valeur Font Char")]
        [Column("FONT_CHAR",Order=9)]
        public Nullable<Int64> FontChar { get; set; }
        
        [Description("Si Style Valeur  Opacity")]
        [Column("OPACITY",Order=10)]
        public Nullable<Double> Opacity { get; set; }
        
    }
}
