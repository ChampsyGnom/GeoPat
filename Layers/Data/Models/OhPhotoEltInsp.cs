using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_ELT_INSP_OH",Schema="OH")]
    public partial class OhPhotoEltInsp
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OH__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpOhIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_OH__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtOhIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_OH__ID_SPRT",Order=2)]
        [Required()]
        public Int64 SprtOhIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=3)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Key]
        [Description("Identifiant élément")]
        [Column("ELT_OH__ID_ELEM",Order=4)]
        [Required()]
        public Int64 EltOhIdElem { get; set; }
        
        [Key]
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=5)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
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
