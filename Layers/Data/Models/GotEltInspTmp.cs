using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_INSP_TMP_GOT",Schema="GOT")]
    public partial class GotEltInspTmp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_GOT__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampGotIdCamp { get; set; }
        
        [Key]
        [Description("N° Ouvrage")]
        [Column("DSC_TEMP_GOT__NUM_GOT",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscTempGotNumGot { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GOT__ID_GRP",Order=2)]
        [Required()]
        public Int64 GrpGotIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GOT__ID_PRT",Order=3)]
        [Required()]
        public Int64 PrtGotIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant sous partie")]
        [Column("SPRT_GOT__ID_SPRT",Order=4)]
        [Required()]
        public Int64 SprtGotIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant Elément")]
        [Column("ELT_GOT__ID_ELEM",Order=5)]
        [Required()]
        public Int64 EltGotIdElem { get; set; }
        
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
