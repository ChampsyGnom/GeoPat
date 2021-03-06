using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_INSP_OA",Schema="OA")]
    public partial class OaEltInsp
    {
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OA__ID_GRP",Order=2)]
        [Required()]
        public Int64 GrpOaIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_OA__ID_PRT",Order=3)]
        [Required()]
        public Int64 PrtOaIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_OA__ID_SPRT",Order=4)]
        [Required()]
        public Int64 SprtOaIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant élément")]
        [Column("ELT_OA__ID_ELEM",Order=5)]
        [Required()]
        public Int64 EltOaIdElem { get; set; }
        
        [Description("Indice")]
        [Column("INDICE",Order=6)]
        [Required()]
        public Int64 Indice { get; set; }
        
        [Description("Observations")]
        [Column("OBS",Order=7)]
        [MaxLength(255)] 
        public String Obs { get; set; }
        
    }
}
