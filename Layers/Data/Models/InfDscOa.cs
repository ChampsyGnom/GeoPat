using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_OA_INF",Schema="INF")]
    public partial class InfDscOa
    {
        [Key]
        [Description("IDOA")]
        [Column("DSC_OA_INF__CODE_OA",Order=0)]
        [Required()]
        public Int64 CodeOa { get; set; }
        
        [Description("NumOA")]
        [Column("DSC_OA_INF__NUM_OA",Order=1)]
        [MaxLength(40)] 
        public String NumOa { get; set; }
        
        [Description("Liaison")]
        [Column("DSC_OA_INF__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("DSC_OA_INF__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR_OA")]
        [Column("DSC_OA_INF__PR_OA",Order=4)]
        [MaxLength(10)] 
        public String PrOa { get; set; }
        
        [Description("Localisation")]
        [Column("DSC_OA_INF__ABS_DEB",Order=5)]
        public Nullable<Int64> AbsDeb { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("DSC_OA_INF__NUM_EXPLOIT",Order=6)]
        [MaxLength(80)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("DSC_OA_INF__NOM_USAGE",Order=7)]
        [MaxLength(100)] 
        public String NomUsage { get; set; }
        
        [Description("Famille")]
        [Column("DSC_OA_INF__FAMILLE",Order=8)]
        [MaxLength(80)] 
        public String Famille { get; set; }
        
        [Description("Type d'ouvrage")]
        [Column("DSC_OA_INF__TYPE_OUVRAGE",Order=9)]
        [MaxLength(80)] 
        public String TypeOuvrage { get; set; }
        
        [Description("Matériaux")]
        [Column("DSC_OA_INF__MATERIAUX",Order=10)]
        [MaxLength(80)] 
        public String Materiaux { get; set; }
        
        [Description("Date MS")]
        [Column("DSC_OA_INF__DATE_MS",Order=11)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Nbre Tabliers")]
        [Column("DSC_OA_INF__NBRE_TABLIERS",Order=12)]
        public Nullable<Int64> NbreTabliers { get; set; }
        
        [Description("Nbre Travées")]
        [Column("DSC_OA_INF__NBRE_TRAVEE",Order=13)]
        public Nullable<Int64> NbreTravee { get; set; }
        
        [Description("Gabarit (m)")]
        [Column("DSC_OA_INF__GABARIT",Order=14)]
        public Nullable<Double> Gabarit { get; set; }
        
        [Description("Longueur (m)")]
        [Column("DSC_OA_INF__LONGUEUR",Order=15)]
        public Nullable<Double> Longueur { get; set; }
        
        [Description("Largeur (m)")]
        [Column("DSC_OA_INF__LARGEUR",Order=16)]
        public Nullable<Double> Largeur { get; set; }
        
        [Description("Section courante")]
        [Column("DSC_OA_INF__SECT_COURANTE",Order=17)]
        public Nullable<Boolean> SectCourante { get; set; }
        
        [Description("Note IQOA")]
        [Column("DSC_OA_INF__IQOA",Order=18)]
        [MaxLength(8)] 
        public String Iqoa { get; set; }
        
        [Description("Niveau d'urgence")]
        [Column("DSC_OA_INF__NOTE_URGENCE",Order=19)]
        public Nullable<Double> NoteUrgence { get; set; }
        
    }
}
