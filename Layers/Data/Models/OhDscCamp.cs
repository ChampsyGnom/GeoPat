using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC_CAMP_OH",Schema="OH")]
    public partial class OhDscCamp
    {
        [Key]
        [Description("NumOH")]
        [Column("DSC_OH__NUM_OH",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOhNumOh { get; set; }
        
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_OH__ID_CAMP",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String CampOhIdCamp { get; set; }
        
        [Description("Contrôle Réalisé")]
        [Column("REALISER",Order=2)]
        public Nullable<Boolean> Realiser { get; set; }
        
    }
}
