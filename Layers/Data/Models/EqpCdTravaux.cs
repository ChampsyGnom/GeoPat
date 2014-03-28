using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TRAVAUX_EQP",Schema="EQP")]
    public partial class EqpCdTravaux
    {
        public virtual ICollection<EqpNatureTrav> EqpNatureTravs { get; set; }
        
        public virtual ICollection<EqpBpu> EqpBpus { get; set; }
        
        [Key]
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_EQP__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Code { get; set; }
        
    }
}
