using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TRAVAUX_GMS",Schema="GMS")]
    public partial class GmsCdTravaux
    {
        public virtual ICollection<GmsNatureTrav> GmsNatureTravs { get; set; }
        
        public virtual ICollection<GmsBpu> GmsBpus { get; set; }
        
        [Key]
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_GMS__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Code { get; set; }
        
    }
}
