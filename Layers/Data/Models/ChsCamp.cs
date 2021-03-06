using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CAMP_CHS",Schema="CHS")]
    public partial class ChsCamp
    {
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Num Section")]
        [Column("SECTION",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String Section { get; set; }
        
        [Key]
        [Description("Année")]
        [Column("ANNEE",Order=2)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON",Order=3)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("SENS",Order=4)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("VOIE",Order=5)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Description("Date génération")]
        [Column("DATEG",Order=6)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Date maxi retour")]
        [Column("DATEC",Order=7)]
        [Required()]
        public DateTime Datec { get; set; }
        
        [Description("Début")]
        [Column("ABS_DEB",Order=8)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=9)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date de chargement")]
        [Column("DATE_LOAD",Order=10)]
        public Nullable<DateTime> DateLoad { get; set; }
        
        [Description("Date des mesures")]
        [Column("DATE_MES",Order=11)]
        public Nullable<DateTime> DateMes { get; set; }
        
        [Description("Pas mesure")]
        [Column("PAS",Order=12)]
        public Nullable<Int64> Pas { get; set; }
        
        [Description("Commentaire")]
        [Column("OBSERV",Order=13)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
