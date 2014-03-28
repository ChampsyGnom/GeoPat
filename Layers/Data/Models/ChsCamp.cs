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
        public virtual ChsCdMesure ChsCdMesure {get;set;}
        
        public virtual ICollection<ChsDetailCamp> ChsDetailCamps { get; set; }
        
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdMesureChsAgr { get; set; }
        
        [Key]
        [Description("Num Section")]
        [Column("CAMP_CHS__SECTION",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String Section { get; set; }
        
        [Key]
        [Description("Année")]
        [Column("CAMP_CHS__ANNEE",Order=2)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("CAMP_CHS__LIAISON",Order=3)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CAMP_CHS__SENS",Order=4)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("CAMP_CHS__VOIE",Order=5)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Description("Date génération")]
        [Column("CAMP_CHS__DATEG",Order=6)]
        public Nullable<DateTime> Dateg { get; set; }
        
        [Description("Date maxi retour")]
        [Column("CAMP_CHS__DATEC",Order=7)]
        [Required()]
        public DateTime Datec { get; set; }
        
        [Description("Début")]
        [Column("CAMP_CHS__ABS_DEB",Order=8)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("CAMP_CHS__ABS_FIN",Order=9)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Date de chargement")]
        [Column("CAMP_CHS__DATE_LOAD",Order=10)]
        public Nullable<DateTime> DateLoad { get; set; }
        
        [Description("Date des mesures")]
        [Column("CAMP_CHS__DATE_MES",Order=11)]
        public Nullable<DateTime> DateMes { get; set; }
        
        [Description("Pas mesure")]
        [Column("CAMP_CHS__PAS",Order=12)]
        public Nullable<Int64> Pas { get; set; }
        
        [Description("Commentaire")]
        [Column("CAMP_CHS__OBSERV",Order=13)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
