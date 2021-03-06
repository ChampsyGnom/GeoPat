using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRECO__SPRT_VST_GOT",Schema="GOT")]
    public partial class GotCdPrecoSprtVst
    {
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_GOT__NUM_GOT",Order=0)]
        [Required()]
        [MaxLength(17)] 
        public String DscGotNumGot { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_GOT__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampGotIdCamp { get; set; }
        
        [Key]
        [Description("Identifiant Bordereau")]
        [Column("BPU_GOT__ID_BPU",Order=2)]
        [Required()]
        public Int64 BpuGotIdBpu { get; set; }
        
        [Description("Entretien réalisé")]
        [Column("REALISE",Order=3)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
