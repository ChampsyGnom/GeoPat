using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PHOTO_VST_OH",Schema="OH")]
    public partial class OhPhotoVst
    {
        [Key]
        [Description("photo vst oh id")]
        [Column("ID",Order=0)]
        [Required()]
        [MaxLength(30)] 
        public String Id { get; set; }
        
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
        [Description("photo vst oh commentaire")]
        [Column("COMMENTAIRE",Order=3)]
        [MaxLength(100)] 
        public String Commentaire { get; set; }
        
    }
}
