using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("WGS_INF",Schema="INF")]
    public partial class InfWgs
    {
        [Description("Index ligne")]
        [Column("WGS_INF__LINE_INDEX",Order=0)]
        [Required()]
        public Int64 LineIndex { get; set; }
        
        [Key]
        [Description("Modèle")]
        [Column("WGS_INF__LAYER_NAME",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String LayerName { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("WGS_INF__LIAISON",Order=2)]
        [Required()]
        [MaxLength(16)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("WGS_INF__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("WGS_INF__ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("WGS_INF__ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("X1")]
        [Column("WGS_INF__X1",Order=6)]
        [Required()]
        public Double X1 { get; set; }
        
        [Description("Y1")]
        [Column("WGS_INF__Y1",Order=7)]
        [Required()]
        public Double Y1 { get; set; }
        
        [Description("X2")]
        [Column("WGS_INF__X2",Order=8)]
        [Required()]
        public Double X2 { get; set; }
        
        [Description("Y2")]
        [Column("WGS_INF__Y2",Order=9)]
        [Required()]
        public Double Y2 { get; set; }
        
    }
}
