using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONCLUSION__INSP_TMP_OA",Schema="OA")]
    public partial class OaCdConclusionInspTmp
    {
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_TEMP_OA__NUM_OA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempOaNumOa { get; set; }
        
        [Key]
        [Description("Identifiant conclusion")]
        [Column("CD_CONCLUSION_OA__ID_CONC",Order=2)]
        [Required()]
        public Int64 CdConclusionOaIdConc { get; set; }
        
        [Description("Contenu")]
        [Column("CONTENU",Order=3)]
        [MaxLength(1000)] 
        public String Contenu { get; set; }
        
    }
}
