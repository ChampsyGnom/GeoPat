using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EVT_CHS",Schema="CHS")]
    public partial class ChsEvt
    {
        public virtual ChsCdEvt ChsCdEvt {get;set;}
        
        public virtual ChsCdPosit ChsCdPosit {get;set;}
        
        [Key]
        [Description("Type événement")]
        [Column("CD_EVT_CHS__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdEvtChsType { get; set; }
        
        [Key]
        [Description("Identifiant Evénement")]
        [Column("EVT_CHS__ID_EVT",Order=1)]
        [Required()]
        public Int64 IdEvt { get; set; }
        
        [Description("Position")]
        [Column("CD_POSIT_CHS__POSIT",Order=2)]
        [MaxLength(60)] 
        public String CdPositChsPosit { get; set; }
        
        [Description("Liaison")]
        [Column("EVT_CHS__LIAISON",Order=3)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("EVT_CHS__SENS",Order=4)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("EVT_CHS__ABS_DEB",Order=5)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR fin")]
        [Column("EVT_CHS__ABS_FIN",Order=6)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date Relevé")]
        [Column("EVT_CHS__DATE_REL",Order=7)]
        [Required()]
        public DateTime DateRel { get; set; }
        
        [Description("Visite annuelle")]
        [Column("EVT_CHS__VSTA",Order=8)]
        public Nullable<Boolean> Vsta { get; set; }
        
        [Description("Observation")]
        [Column("EVT_CHS__OBSV",Order=9)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
        [Description("Date Traitement")]
        [Column("EVT_CHS__DATE_TRT",Order=10)]
        public Nullable<DateTime> DateTrt { get; set; }
        
    }
}
