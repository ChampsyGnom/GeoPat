using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MAP_METIER_COLUMNS",Schema="MAPINFO")]
    public partial class MapinfoTbMapMetierColumns
    {
        [Key]
        [Description("Tb Map Metier  Schema Name")]
        [Column("TB_MAP_METIER__SCHEMA_NAME",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String TbMapMetierSchemaName { get; set; }
        
        [Key]
        [Description("Tb Map Metier  Table Name")]
        [Column("TB_MAP_METIER__TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String TbMapMetierTableName { get; set; }
        
        [Key]
        [Description("Tb Map Metier Columns  Col Name")]
        [Column("COL_NAME",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String ColName { get; set; }
        
        [Description("Tb Map Metier Columns  Col Libelle")]
        [Column("COL_LIBELLE",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String ColLibelle { get; set; }
        
        [Description("Tb Map Metier Columns  Col Order")]
        [Column("COL_ORDER",Order=4)]
        public Nullable<Int64> ColOrder { get; set; }
        
        [Description("Tb Map Metier Columns  Col Visible")]
        [Column("COL_VISIBLE",Order=5)]
        public Nullable<Int64> ColVisible { get; set; }
        
    }
}
