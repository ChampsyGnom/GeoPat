using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_ELT_INSP_BSN",Schema="BSN")]
    public partial class BsnPhotoEltInsp
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_BSN__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpBsnIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_BSN__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtBsnIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_BSN__ID_SPRT",Order=2)]
        [Required()]
        public Int64 SprtBsnIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=3)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("Identifiant Elément")]
        [Column("ELT_BSN__ID_ELEM",Order=4)]
        [Required()]
        public Int64 EltBsnIdElem { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=5)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
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
