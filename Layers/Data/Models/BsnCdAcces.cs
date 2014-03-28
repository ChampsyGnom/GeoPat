using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ACCES_BSN",Schema="BSN")]
    public partial class BsnCdAcces
    {
        public virtual ICollection<BsnDsc> BsnDscs { get; set; }
        
        public virtual ICollection<BsnDscTemp> BsnDscTemps { get; set; }
        
        [Key]
        [Description("Voie d'accès")]
        [Column("CD_ACCES_BSN__VACCES",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Vacces { get; set; }
        
    }
}
