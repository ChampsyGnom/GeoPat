using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EVT_INF",Schema="INF")]
    public partial class InfEvt
    {
        public virtual InfCdEvt InfCdEvt {get;set;}
        
        public virtual InfCdPosit InfCdPosit {get;set;}
        
        [Key]
        [Description("Type événement")]
        [Column("CD_EVT_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdEvtInfType { get; set; }
        
        [Key]
        [Description("Identifiant Evénement")]
        [Column("EVT_INF__ID_EVT",Order=1)]
        [Required()]
        public Int64 IdEvt { get; set; }
        
        [Description("Position")]
        [Column("CD_POSIT_INF__POSIT",Order=2)]
        [MaxLength(12)] 
        public String CdPositInfPosit { get; set; }
        
        [Description("Nom Table")]
        [Column("EVT_INF__NOM_TABLE",Order=3)]
        [Required()]
        [MaxLength(60)] 
        public String NomTable { get; set; }
        
        [Description("Liaison")]
        [Column("EVT_INF__LIAISON",Order=4)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("EVT_INF__SENS",Order=5)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("EVT_INF__ABS_DEB",Order=6)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR fin")]
        [Column("EVT_INF__ABS_FIN",Order=7)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date Relevé")]
        [Column("EVT_INF__DATE_REL",Order=8)]
        [Required()]
        public DateTime DateRel { get; set; }
        
        [Description("Observation")]
        [Column("EVT_INF__OBSV",Order=9)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
        [Description("Date Traitement")]
        [Column("EVT_INF__DATE_TRT",Order=10)]
        public Nullable<DateTime> DateTrt { get; set; }
        
    }
}
