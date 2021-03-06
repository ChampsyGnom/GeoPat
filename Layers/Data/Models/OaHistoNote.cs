using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("HISTO_NOTE_OA",Schema="OA")]
    public partial class OaHistoNote
    {
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Date Note")]
        [Column("DATE_NOTE",Order=1)]
        [Required()]
        public DateTime DateNote { get; set; }
        
        [Description("Origine")]
        [Column("CD_ORIGIN_OA__ORIGINE",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String CdOriginOaOrigine { get; set; }
        
        [Description("Note IQOA")]
        [Column("NOTE_IQOA",Order=3)]
        [MaxLength(3)] 
        public String NoteIqoa { get; set; }
        
        [Description("Note Appuis")]
        [Column("NOTE1",Order=4)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Tablier")]
        [Column("NOTE2",Order=5)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Equipement")]
        [Column("NOTE3",Order=6)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=7)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=8)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence Traitement")]
        [Column("PRIORITAIRE",Order=9)]
        [Required()]
        public Boolean Prioritaire { get; set; }
        
    }
}
