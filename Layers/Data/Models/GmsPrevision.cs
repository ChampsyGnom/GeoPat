using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_GMS",Schema="GMS")]
    public partial class GmsPrevision
    {
        public virtual GmsDsc GmsDsc {get;set;}
        
        public virtual GmsCdContrainte GmsCdContrainte {get;set;}
        
        public virtual GmsBpu GmsBpu {get;set;}
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_GMS__ID_BPU",Order=1)]
        [Required()]
        public Int64 BpuGmsIdBpu { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("PREVISION_GMS__DATE_DEBUT",Order=2)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_GMS__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteGmsType { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_GMS__DATE_FIN",Order=4)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Coûts (€)")]
        [Column("PREVISION_GMS__MONTANT",Order=5)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date demande publication")]
        [Column("PREVISION_GMS__DATE_DEM_PUB",Order=6)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_GMS__COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_GMS__REALISE",Order=8)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
