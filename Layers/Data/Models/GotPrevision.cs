using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_GOT",Schema="GOT")]
    public partial class GotPrevision
    {
        public virtual GotBpu GotBpu {get;set;}
        
        public virtual GotCdContrainte GotCdContrainte {get;set;}
        
        public virtual GotDsc GotDsc {get;set;}
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_GOT__ID_BPU",Order=0)]
        [Required()]
        public Int64 BpuGotIdBpu { get; set; }
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_GOT__NUM_GOT",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("PREVISION_GOT__DATE_DEBUT",Order=2)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_GOT__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteGotType { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_GOT__DATE_FIN",Order=4)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Coûts (€)")]
        [Column("PREVISION_GOT__MONTANT",Order=5)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date demande publication")]
        [Column("PREVISION_GOT__DATE_DEM_PUB",Order=6)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_GOT__COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_GOT__REALISE",Order=8)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
