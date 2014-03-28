using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRESTA_OA",Schema="OA")]
    public partial class OaCdPresta
    {
        public virtual ICollection<OaCamp> OaCamps { get; set; }
        
        public virtual ICollection<OaInspecteur> OaInspecteurs { get; set; }
        
        [Key]
        [Description("Prestataire")]
        [Column("CD_PRESTA_OA__PRESTATAIRE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Prestataire { get; set; }
        
    }
}
