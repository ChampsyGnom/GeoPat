using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREV_SGE_INF",Schema="INF")]
    public partial class InfPrevSge
    {
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Base métier")]
        [Column("SCHEMA",Order=2)]
        [Required()]
        [MaxLength(5)] 
        public String Schema { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("DATE_DEB",Order=3)]
        [Required()]
        public DateTime DateDeb { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Nature")]
        [Column("NATURE",Order=5)]
        [Required()]
        [MaxLength(125)] 
        public String Nature { get; set; }
        
        [Key]
        [Description("Num Ouvrage")]
        [Column("NUM_OUVRAGE",Order=6)]
        [Required()]
        [MaxLength(20)] 
        public String NumOuvrage { get; set; }
        
        [Description("Date fin")]
        [Column("DATE_FIN",Order=7)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=8)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Contrainte d'exploit")]
        [Column("CE",Order=9)]
        [MaxLength(100)] 
        public String Ce { get; set; }
        
        [Description("Date Publication")]
        [Column("DATE_PUB",Order=10)]
        public Nullable<DateTime> DatePub { get; set; }
        
        [Description("Date Fin Publication")]
        [Column("DATE_FINPUB",Order=11)]
        public Nullable<DateTime> DateFinpub { get; set; }
        
        [Description("Date demande")]
        [Column("DATE_DEMANDE",Order=12)]
        public Nullable<DateTime> DateDemande { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM_USAGE",Order=13)]
        [MaxLength(30)] 
        public String NomUsage { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=14)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
