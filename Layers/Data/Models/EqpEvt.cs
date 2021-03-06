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
        [Column("ID_EVT",Order=2)]
        [Required()]
        public Int64 IdEvt { get; set; }
        
        [Description("Position")]
        [Column("CD_POSIT_EQP__POSIT",Order=3)]
        [MaxLength(60)] 
        public String CdPositEqpPosit { get; set; }
        
        [Description("N° Exploitation")]
        [Column("OUVRAGE",Order=4)]
        [MaxLength(30)] 
        public String Ouvrage { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=5)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=6)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR début")]
        [Column("ABS_DEB",Order=7)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR fin")]
        [Column("ABS_FIN",Order=8)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date Relevé")]
        [Column("DATE_REL",Order=9)]
        [Required()]
        public DateTime DateRel { get; set; }
        
        [Description("Observation")]
        [Column("OBSV",Order=10)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
        [Description("Date Traitement")]
        [Column("DATE_TRT",Order=11)]
        public Nullable<DateTime> DateTrt { get; set; }
        
    }
}
