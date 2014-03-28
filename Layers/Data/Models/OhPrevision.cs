using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_OH",Schema="OH")]
    public partial class OhPrevision
    {
        public virtual OhDsc OhDsc {get;set;}
        
        public virtual OhBpu OhBpu {get;set;}
        
        public virtual OhCdContrainte OhCdContrainte {get;set;}
        
        [Key]
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_OH__ID_BPU",Order=1)]
        [Required()]
        public Int64 BpuOhIdBpu { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("PREVISION_OH__DATE_DEBUT",Order=2)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_OH__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteOhType { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_OH__DATE_FIN",Order=4)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Coûts (€)")]
        [Column("PREVISION_OH__MONTANT",Order=5)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date demande publication")]
        [Column("PREVISION_OH__DATE_DEM_PUB",Order=6)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_OH__COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_OH__REALISE",Order=8)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
