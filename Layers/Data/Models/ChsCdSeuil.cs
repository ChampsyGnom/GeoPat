using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SEUIL_CHS",Schema="CHS")]
    public partial class ChsCdSeuil
    {
        public virtual ChsCdIndic ChsCdIndic {get;set;}
        
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
        public String CdIndicChsIndic { get; set; }
        
        [Description("< Seuil 1")]
        [Column("CD_SEUIL_CHS__SEUIL1",Order=2)]
        [Required()]
        public Double Seuil1 { get; set; }
        
        [Description("< Seuil 2")]
        [Column("CD_SEUIL_CHS__SEUIL2",Order=3)]
        public Nullable<Double> Seuil2 { get; set; }
        
        [Description("< Seuil 3")]
        [Column("CD_SEUIL_CHS__SEUIL3",Order=4)]
        public Nullable<Double> Seuil3 { get; set; }
        
        [Description(">= Seuil 4")]
        [Column("CD_SEUIL_CHS__SEUIL4",Order=5)]
        public Nullable<Double> Seuil4 { get; set; }
        
        [Description("Sens interprétation")]
        [Column("CD_SEUIL_CHS__INTERP",Order=6)]
        [Required()]
        [MaxLength(1)] 
        public String Interp { get; set; }
        
        [Description("Valeur Absolue")]
        [Column("CD_SEUIL_CHS__VALABS",Order=7)]
        [Required()]
        public Boolean Valabs { get; set; }
        
        [Description("Zone Homogène")]
        [Column("CD_SEUIL_CHS__ZONE",Order=8)]
        public Nullable<Boolean> Zone { get; set; }
        
        [Description("U Alpha")]
        [Column("CD_SEUIL_CHS__U_ALPHA",Order=9)]
        public Nullable<Double> UAlpha { get; set; }
        
        [Description("Caractéristique Ecart")]
        [Column("CD_SEUIL_CHS__CARACT_ECART",Order=10)]
        public Nullable<Double> CaractEcart { get; set; }
        
    }
}
