using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TRAVAUX_BSN",Schema="BSN")]
    public partial class BsnCdTravaux
    {
        public virtual ICollection<BsnNatureTrav> BsnNatureTravs { get; set; }
        
        public virtual ICollection<BsnBpu> BsnBpus { get; set; }
        
        [Key]
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_BSN__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Code { get; set; }
        
    }
}
