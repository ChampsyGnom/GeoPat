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
        [Key]
        [Description("Tb Map Metier  Schema Name")]
        [Column("SCHEMA_NAME",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String SchemaName { get; set; }
        
        [Key]
        [Description("Tb Map Metier  Table Name")]
        [Column("TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String TableName { get; set; }
        
        [Description("Tb Map Metier  Title")]
        [Column("TITLE",Order=2)]
        [MaxLength(50)] 
        public String Title { get; set; }
        
        [Description("Tb Map Metier  Map Order")]
        [Column("MAP_ORDER",Order=3)]
        public Nullable<Int64> MapOrder { get; set; }
        
        [Description("Tb Map Metier  Rang")]
        [Column("RANG",Order=4)]
        public Nullable<Int64> Rang { get; set; }
        
        [Description("Tb Map Metier  ObjType")]
        [Column("OBJTYPE",Order=5)]
        public Nullable<Int64> Objtype { get; set; }
        
    }
}
