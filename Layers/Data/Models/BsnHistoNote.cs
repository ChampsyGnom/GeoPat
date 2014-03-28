using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("HISTO_NOTE_BSN",Schema="BSN")]
    public partial class BsnHistoNote
    {
        public virtual BsnDsc BsnDsc {get;set;}
        
        public virtual BsnCdOrigin BsnCdOrigin {get;set;}
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Date Note")]
        [Column("HISTO_NOTE_BSN__DATE_NOTE",Order=1)]
        [Required()]
        public DateTime DateNote { get; set; }
        
        [Description("Origine Note")]
        [Column("CD_ORIGIN_BSN__ORIGINE",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String CdOriginBsnOrigine { get; set; }
        
        [Description("Note Structure")]
        [Column("HISTO_NOTE_BSN__NOTE1",Order=3)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Equipements")]
        [Column("HISTO_NOTE_BSN__NOTE2",Order=4)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Abords-Végétation")]
        [Column("HISTO_NOTE_BSN__NOTE3",Order=5)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Sécurité")]
        [Column("HISTO_NOTE_BSN__NOTE4",Order=6)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("HISTO_NOTE_BSN__URGENCE",Order=7)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("HISTO_NOTE_BSN__SECURITE",Order=8)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("HISTO_NOTE_BSN__PRIORITAIRE",Order=9)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
    }
}
