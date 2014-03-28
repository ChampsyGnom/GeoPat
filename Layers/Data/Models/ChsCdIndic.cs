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
        public virtual ChsCdMesure ChsCdMesure {get;set;}
        
        public virtual ICollection<ChsCdSeuil> ChsCdSeuils { get; set; }
        
        public virtual ICollection<ChsDetailCamp> ChsDetailCamps { get; set; }
        
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Indicateur")]
        [Column("CD_INDIC_CHS__INDIC",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String Indic { get; set; }
        
        [Description("Libellé")]
        [Column("CD_INDIC_CHS__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Unité")]
        [Column("CD_INDIC_CHS__UNITE",Order=3)]
        [MaxLength(8)] 
        public String Unite { get; set; }
        
        [Description("Min")]
        [Column("CD_INDIC_CHS__VMIN",Order=4)]
        public Nullable<Int64> Vmin { get; set; }
        
        [Description("Max")]
        [Column("CD_INDIC_CHS__VMAX",Order=5)]
        public Nullable<Int64> Vmax { get; set; }
        
        [Description("Invalide")]
        [Column("CD_INDIC_CHS__INVALIDE",Order=6)]
        public Nullable<Int64> Invalide { get; set; }
        
        [Description("Format Ind")]
        [Column("CD_INDIC_CHS__FORMATS",Order=7)]
        [MaxLength(12)] 
        public String Formats { get; set; }
        
    }
}
