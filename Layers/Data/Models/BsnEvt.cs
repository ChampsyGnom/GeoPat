using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EVT_BSN",Schema="BSN")]
    public partial class BsnEvt
    {
        [Key]
        [Description("Type événement")]
        [Column("CD_EVT_BSN__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdEvtBsnType { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Date Relevé")]
        [Column("DATE_REL",Order=2)]
        [Required()]
        public DateTime DateRel { get; set; }
        
        [Description("Date Traitement")]
        [Column("DATE_TRT",Order=3)]
        public Nullable<DateTime> DateTrt { get; set; }
        
        [Description("Observation")]
        [Column("OBSV",Order=4)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
    }
}
