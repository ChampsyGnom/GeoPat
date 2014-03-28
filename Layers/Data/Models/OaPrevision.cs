using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_OA",Schema="OA")]
    public partial class OaPrevision
    {
        public virtual OaCdContrainte OaCdContrainte {get;set;}
        
        public virtual OaDsc OaDsc {get;set;}
        
        public virtual OaBpu OaBpu {get;set;}
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_OA__ID_BPU",Order=1)]
        [Required()]
        public Int64 BpuOaIdBpu { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("PREVISION_OA__DATE_DEBUT",Order=2)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Contrainte Exploit.")]
        [Column("CD_CONTRAINTE_OA__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteOaType { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_OA__DATE_FIN",Order=4)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Coûts (€)")]
        [Column("PREVISION_OA__MONTANT",Order=5)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date demande publication")]
        [Column("PREVISION_OA__DATE_DEM_PUB",Order=6)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_OA__COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_OA__REALISE",Order=8)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
