using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_INSP_OA",Schema="OA")]
    public partial class OaPhotoInsp
    {
        public virtual OaInsp OaInsp {get;set;}
        
        [Key]
        [Description("Identifiant")]
        [Column("PHOTO_INSP_OA__ID",Order=0)]
        [Required()]
        [MaxLength(30)] 
        public String Id { get; set; }
        
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Description("Identifiant campagne")]
        [Column("CAMP_OA__ID_CAMP",Order=2)]
        [Required()]
        [MaxLength(100)] 
        public String CampOaIdCamp { get; set; }
        
        [Description("Commentaire")]
        [Column("PHOTO_INSP_OA__COMMENTAIRE",Order=3)]
        [MaxLength(100)] 
        public String Commentaire { get; set; }
        
    }
}
