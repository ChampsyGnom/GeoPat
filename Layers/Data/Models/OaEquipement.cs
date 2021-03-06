using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EQUIPEMENT_OA",Schema="OA")]
    public partial class OaEquipement
    {
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("N° Tablier")]
        [Column("TABLIER_OA__NUM_TAB",Order=1)]
        [Required()]
        public Int64 TablierOaNumTab { get; set; }
        
        [Key]
        [Description("Coté")]
        [Column("COTE",Order=2)]
        [Required()]
        [MaxLength(1)] 
        public String Cote { get; set; }
        
        [Description("Dispositif de retenue")]
        [Column("CD_DPR_OA__DPR",Order=3)]
        [MaxLength(60)] 
        public String CdDprOaDpr { get; set; }
        
        [Description("Garde-corps")]
        [Column("CD_GC_OA__GARDE_CORPS",Order=4)]
        [MaxLength(60)] 
        public String CdGcOaGardeCorps { get; set; }
        
        [Description("Date MS DPR")]
        [Column("DATE_DPR",Order=5)]
        public Nullable<DateTime> DateDpr { get; set; }
        
        [Description("Date MS GC")]
        [Column("DATE_GC",Order=6)]
        public Nullable<DateTime> DateGc { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
