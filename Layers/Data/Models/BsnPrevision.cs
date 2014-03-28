using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_BSN",Schema="BSN")]
    public partial class BsnPrevision
    {
        public virtual BsnDsc BsnDsc {get;set;}
        
        public virtual BsnBpu BsnBpu {get;set;}
        
        public virtual BsnCdContrainte BsnCdContrainte {get;set;}
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_BSN__ID_BPU",Order=1)]
        [Required()]
        public Int64 BpuBsnIdBpu { get; set; }
        
        [Key]
        [Description("Date début")]
        [Column("PREVISION_BSN__DATE_DEBUT",Order=2)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_BSN__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteBsnType { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_BSN__DATE_FIN",Order=4)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Coûts")]
        [Column("PREVISION_BSN__MONTANT",Order=5)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date demande publication")]
        [Column("PREVISION_BSN__DATE_DEM_PUB",Order=6)]
        public Nullable<DateTime> DateDemPub { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_BSN__COMMENTAIRE",Order=7)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_BSN__REALISE",Order=8)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
