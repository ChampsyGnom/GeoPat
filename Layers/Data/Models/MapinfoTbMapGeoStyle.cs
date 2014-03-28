using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MAP_GEO_STYLE",Schema="MAPINFO")]
    public partial class MapinfoTbMapGeoStyle
    {
        [Key]
        [Description("Map")]
        [Column("TB_MAP_GEO_STYLE__MAP",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Map { get; set; }
        
        [Key]
        [Description("UserName")]
        [Column("TB_MAP_GEO_STYLE__USERNAME",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String Username { get; set; }
        
        [Key]
        [Description("Représentation")]
        [Column("TB_MAP_GEO_STYLE__REPRESENTATION",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Representation { get; set; }
        
        [Description("Couleur")]
        [Column("TB_MAP_GEO_STYLE__COLOR",Order=3)]
        [Required()]
        public Int64 Color { get; set; }
        
        [Description("Largeur")]
        [Column("TB_MAP_GEO_STYLE__WIDTH",Order=4)]
        [Required()]
        public Int64 Width { get; set; }
        
        [Description("Police")]
        [Column("TB_MAP_GEO_STYLE__FONT",Order=5)]
        [MaxLength(50)] 
        public String Font { get; set; }
        
        [Description("Code ASCII")]
        [Column("TB_MAP_GEO_STYLE__ASCII",Order=6)]
        public Nullable<Int64> Ascii { get; set; }
        
        [Description("Style")]
        [Column("TB_MAP_GEO_STYLE__STYLE",Order=7)]
        public Nullable<Int64> Style { get; set; }
        
        [Description("Interleaved")]
        [Column("TB_MAP_GEO_STYLE__INTERLEAVED",Order=8)]
        public Nullable<Int64> Interleaved { get; set; }
        
        [Description("BorderColor")]
        [Column("TB_MAP_GEO_STYLE__BORDERCOLOR",Order=9)]
        public Nullable<Int64> Bordercolor { get; set; }
        
        [Description("BorderStyle")]
        [Column("TB_MAP_GEO_STYLE__BORDERSTYLE",Order=10)]
        public Nullable<Int64> Borderstyle { get; set; }
        
        [Description("RegionBackground")]
        [Column("TB_MAP_GEO_STYLE__REGIONBACKGROUND",Order=11)]
        public Nullable<Int64> Regionbackground { get; set; }
        
    }
}
