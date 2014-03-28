using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_INSP_BSN",Schema="BSN")]
    public partial class BsnPhotoInsp
    {
        public virtual BsnInsp BsnInsp {get;set;}
        
        [Key]
        [Description("Identifiant")]
        [Column("PHOTO_INSP_BSN__ID",Order=0)]
        [Required()]
        [MaxLength(30)] 
        public String Id { get; set; }
        
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Description("Commentaire")]
        [Column("PHOTO_INSP_BSN__COMMENTAIRE",Order=3)]
        [MaxLength(100)] 
        public String Commentaire { get; set; }
        
    }
}
