using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MAP_METIER",Schema="MAPINFO")]
    public partial class MapinfoTbMapMetier
    {
        public virtual ICollection<MapinfoTbMapMetierCfg> MapinfoTbMapMetierCfgs { get; set; }
        
        public virtual ICollection<MapinfoTbMapMetierColumns> MapinfoTbMapMetierColumnss { get; set; }
        
        [Key]
        [Description("Tb Map Metier  Schema Name")]
        [Column("TB_MAP_METIER__SCHEMA_NAME",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String SchemaName { get; set; }
        
        [Key]
        [Description("Tb Map Metier  Table Name")]
        [Column("TB_MAP_METIER__TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String TableName { get; set; }
        
        [Description("Tb Map Metier  Title")]
        [Column("TB_MAP_METIER__TITLE",Order=2)]
        [MaxLength(50)] 
        public String Title { get; set; }
        
        [Description("Tb Map Metier  Map Order")]
        [Column("TB_MAP_METIER__MAP_ORDER",Order=3)]
        public Nullable<Int64> MapOrder { get; set; }
        
        [Description("Tb Map Metier  Rang")]
        [Column("TB_MAP_METIER__RANG",Order=4)]
        public Nullable<Int64> Rang { get; set; }
        
        [Description("Tb Map Metier  ObjType")]
        [Column("TB_MAP_METIER__OBJTYPE",Order=5)]
        public Nullable<Int64> Objtype { get; set; }
        
    }
}
