using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRECO__SPRT_VST_BSN",Schema="BSN")]
    public partial class BsnCdPrecoSprtVst
    {
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_BSN__ID_CHAP",Order=2)]
        [Required()]
        public Int64 CdChapitreBsnIdChap { get; set; }
        
        [Key]
        [Description("Identifiant ligne")]
        [Column("CD_LIGNE_BSN__ID_LIGNE",Order=3)]
        [Required()]
        public Int64 CdLigneBsnIdLigne { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_BSN__ID_BPU",Order=4)]
        [Required()]
        public Int64 BpuBsnIdBpu { get; set; }
        
        [Description("Entretien réalisé")]
        [Column("REALISE",Order=5)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
