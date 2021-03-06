using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_INSP_TMP_BSN",Schema="BSN")]
    public partial class BsnEltInspTmp
    {
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_TEMP_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempBsnNumBsn { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_BSN__ID_GRP",Order=2)]
        [Required()]
        public Int64 GrpBsnIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_BSN__ID_PRT",Order=3)]
        [Required()]
        public Int64 PrtBsnIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_BSN__ID_SPRT",Order=4)]
        [Required()]
        public Int64 SprtBsnIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant Elément")]
        [Column("ELT_BSN__ID_ELEM",Order=5)]
        [Required()]
        public Int64 EltBsnIdElem { get; set; }
        
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
