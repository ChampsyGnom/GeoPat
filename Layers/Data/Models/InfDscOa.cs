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
        [Column("CODE_OA",Order=0)]
        [Required()]
        public Int64 CodeOa { get; set; }
        
        [Description("NumOA")]
        [Column("NUM_OA",Order=1)]
        [MaxLength(40)] 
        public String NumOa { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("PR_OA")]
        [Column("PR_OA",Order=4)]
        [MaxLength(10)] 
        public String PrOa { get; set; }
        
        [Description("Localisation")]
        [Column("ABS_DEB",Order=5)]
        public Nullable<Int64> AbsDeb { get; set; }
        
        [Description("N° d'exploitation")]
        [Column("NUM_EXPLOIT",Order=6)]
        [MaxLength(80)] 
        public String NumExploit { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM_USAGE",Order=7)]
        [MaxLength(100)] 
        public String NomUsage { get; set; }
        
        [Description("Famille")]
        [Column("FAMILLE",Order=8)]
        [MaxLength(80)] 
        public String Famille { get; set; }
        
        [Description("Type d'ouvrage")]
        [Column("TYPE_OUVRAGE",Order=9)]
        [MaxLength(80)] 
        public String TypeOuvrage { get; set; }
        
        [Description("Matériaux")]
        [Column("MATERIAUX",Order=10)]
        [MaxLength(80)] 
        public String Materiaux { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=11)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Nbre Tabliers")]
        [Column("NBRE_TABLIERS",Order=12)]
        public Nullable<Int64> NbreTabliers { get; set; }
        
        [Description("Nbre Travées")]
        [Column("NBRE_TRAVEE",Order=13)]
        public Nullable<Int64> NbreTravee { get; set; }
        
        [Description("Gabarit (m)")]
        [Column("GABARIT",Order=14)]
        public Nullable<Double> Gabarit { get; set; }
        
        [Description("Longueur (m)")]
        [Column("LONGUEUR",Order=15)]
        public Nullable<Double> Longueur { get; set; }
        
        [Description("Largeur (m)")]
        [Column("LARGEUR",Order=16)]
        public Nullable<Double> Largeur { get; set; }
        
        [Description("Section courante")]
        [Column("SECT_COURANTE",Order=17)]
        public Nullable<Boolean> SectCourante { get; set; }
        
        [Description("Note IQOA")]
        [Column("IQOA",Order=18)]
        [MaxLength(8)] 
        public String Iqoa { get; set; }
        
        [Description("Niveau d'urgence")]
        [Column("NOTE_URGENCE",Order=19)]
        public Nullable<Double> NoteUrgence { get; set; }
        
    }
}
