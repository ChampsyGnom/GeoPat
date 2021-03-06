using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_ELT_INSP_TMP_OA",Schema="OA")]
    public partial class OaPhotoEltInspTmp
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OA__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpOaIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_OA__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtOaIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_OA__ID_SPRT",Order=2)]
        [Required()]
        public Int64 SprtOaIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=3)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_TEMP_OA__NUM_OA",Order=4)]
        [Required()]
        [MaxLength(20)] 
        public String DscTempOaNumOa { get; set; }
        
        [Key]
        [Description("Identifiant élément")]
        [Column("ELT_OA__ID_ELEM",Order=5)]
        [Required()]
        public Int64 EltOaIdElem { get; set; }
        
        [Key]
        [Description("Identifiant de la photo")]
        [Column("ID",Order=6)]
        [Required()]
        [MaxLength(50)] 
        public String Id { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=7)]
        [MaxLength(100)] 
        public String Commentaire { get; set; }
        
    }
}
