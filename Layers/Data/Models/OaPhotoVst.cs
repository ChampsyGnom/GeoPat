using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_VST_OA",Schema="OA")]
    public partial class OaPhotoVst
    {
        [Key]
        [Description("Identifiant")]
        [Column("ID",Order=0)]
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
        [Column("COMMENTAIRE",Order=3)]
        [MaxLength(100)] 
        public String Commentaire { get; set; }
        
    }
}
