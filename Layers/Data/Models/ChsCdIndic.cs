using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_INDIC_CHS",Schema="CHS")]
    public partial class ChsCdIndic
    {
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Indicateur")]
        [Column("INDIC",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String Indic { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Unité")]
        [Column("UNITE",Order=3)]
        [MaxLength(8)] 
        public String Unite { get; set; }
        
        [Description("Min")]
        [Column("VMIN",Order=4)]
        public Nullable<Int64> Vmin { get; set; }
        
        [Description("Max")]
        [Column("VMAX",Order=5)]
        public Nullable<Int64> Vmax { get; set; }
        
        [Description("Invalide")]
        [Column("INVALIDE",Order=6)]
        public Nullable<Int64> Invalide { get; set; }
        
        [Description("Format Ind")]
        [Column("FORMATS",Order=7)]
        [MaxLength(12)] 
        public String Formats { get; set; }
        
    }
}
