using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EVT_EQP",Schema="EQP")]
    public partial class EqpEvt
    {
        public virtual EqpCdType EqpCdType {get;set;}
        
        public virtual EqpCdEvt EqpCdEvt {get;set;}
        
        public virtual EqpCdPosit EqpCdPosit {get;set;}
        
        [Key]
        [Description("Type d'équipement")]
        [Column("CD_TYPE_EQP__TYPE_EQUIP",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String CdTypeEqpTypeEquip { get; set; }
        
        [Key]
        [Description("Type événement")]
        [Column("CD_EVT_EQP__TYPE",Order=1)]
        [Required()]
        [MaxLength(25)] 
        public String CdEvtEqpType { get; set; }
        
        [Key]
        [Description("Identifiant Evénement")]
        [Column("EVT_EQP__ID_EVT",Order=2)]
        [Required()]
        public Int64 IdEvt { get; set; }
        
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=3)]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Description("N° Exploitation")]
        [Column("EVT_EQP__OUVRAGE",Order=4)]
        [MaxLength(30)] 
        public String Ouvrage { get; set; }
        
        [Description("Liaison")]
        [Column("EVT_EQP__LIAISON",Order=5)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("EVT_EQP__SENS",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("EVT_EQP__ABS_DEB",Order=7)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR fin")]
        [Column("EVT_EQP__ABS_FIN",Order=8)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date Relevé")]
        [Column("EVT_EQP__DATE_REL",Order=9)]
        [Required()]
        public DateTime DateRel { get; set; }
        
        [Description("Observation")]
        [Column("EVT_EQP__OBSV",Order=10)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
        [Description("Date Traitement")]
        [Column("EVT_EQP__DATE_TRT",Order=11)]
        public Nullable<DateTime> DateTrt { get; set; }
        
    }
}
