using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("OCCUPATION_OA",Schema="OA")]
    public partial class OaOccupation
    {
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Nom occupant")]
        [Column("CD_OCCUPANT_OA__NOM",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdOccupantOaNom { get; set; }
        
        [Key]
        [Description("Type Occupation")]
        [Column("CD_OCCUP_OA__TYPE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdOccupOaType { get; set; }
        
        [Description("Date Début")]
        [Column("DATE_MS",Order=3)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Date Fin")]
        [Column("DATE_FV",Order=4)]
        public Nullable<DateTime> DateFv { get; set; }
        
        [Description("Traversé")]
        [Column("TRAV",Order=5)]
        public Nullable<Boolean> Trav { get; set; }
        
        [Description("N° convention")]
        [Column("NUM_CONV",Order=6)]
        [MaxLength(60)] 
        public String NumConv { get; set; }
        
        [Description("Commentaires")]
        [Column("OBSERV",Order=7)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
