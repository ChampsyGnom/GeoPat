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
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Date Note")]
        [Column("DATE_NOTE",Order=1)]
        [Required()]
        public DateTime DateNote { get; set; }
        
        [Description("Origine Note")]
        [Column("CD_ORIGIN_BSN__ORIGINE",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String CdOriginBsnOrigine { get; set; }
        
        [Description("Note Structure")]
        [Column("NOTE1",Order=3)]
        public Nullable<Int64> Note1 { get; set; }
        
        [Description("Note Equipements")]
        [Column("NOTE2",Order=4)]
        public Nullable<Int64> Note2 { get; set; }
        
        [Description("Note Abords-Végétation")]
        [Column("NOTE3",Order=5)]
        public Nullable<Int64> Note3 { get; set; }
        
        [Description("Note Sécurité")]
        [Column("NOTE4",Order=6)]
        public Nullable<Int64> Note4 { get; set; }
        
        [Description("Niveau Urgence")]
        [Column("URGENCE",Order=7)]
        [MaxLength(5)] 
        public String Urgence { get; set; }
        
        [Description("Problème de sécurité")]
        [Column("SECURITE",Order=8)]
        public Nullable<Boolean> Securite { get; set; }
        
        [Description("Urgence traitement")]
        [Column("PRIORITAIRE",Order=9)]
        public Nullable<Boolean> Prioritaire { get; set; }
        
    }
}
