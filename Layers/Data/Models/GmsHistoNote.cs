using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("HISTO_NOTE_GMS",Schema="GMS")]
    public partial class GmsHistoNote
    {
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Date Note")]
        [Column("DATE_NOTE",Order=1)]
        [Required()]
        public DateTime DateNote { get; set; }
        
        [Description("Origine Note")]
        [Column("CD_ORIGIN_GMS__ORIGINE",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String CdOriginGmsOrigine { get; set; }
        
        [Description("Note Ancrage")]
        [Column("NOTE1",Order=3)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Structure")]
        [Column("NOTE2",Order=4)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Fixation")]
        [Column("NOTE3",Order=5)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Panneau")]
        [Column("NOTE4",Order=6)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Note Accessibilité")]
        [Column("NOTE5",Order=7)]
        public Nullable<Int64> Note5 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=8)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=9)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=10)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
    }
}
