using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_INSP_GMS",Schema="GMS")]
    public partial class GmsEltInsp
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GMS__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpGmsIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GMS__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtGmsIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_GMS__ID_SPRT",Order=2)]
        [Required()]
        public Int64 SprtGmsIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant élément")]
        [Column("ELT_GMS__ID_ELEM",Order=3)]
        [Required()]
        public Int64 EltGmsIdElem { get; set; }
        
        [Key]
        [Description("Identifiant")]
        [Column("CAMP_GMS__ID_CAMP",Order=4)]
        [Required()]
        [MaxLength(100)] 
        public String CampGmsIdCamp { get; set; }
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=5)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Description("Indice")]
        [Column("INDICE",Order=6)]
        [Required()]
        public Int64 Indice { get; set; }
        
        [Description("Observation")]
        [Column("OBS",Order=7)]
        [MaxLength(255)] 
        public String Obs { get; set; }
        
    }
}
