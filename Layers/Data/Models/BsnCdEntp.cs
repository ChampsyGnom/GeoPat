using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ENTP_BSN",Schema="BSN")]
    public partial class BsnCdEntp
    {
        public virtual ICollection<BsnTravaux> BsnTravauxs { get; set; }
        
        public virtual ICollection<BsnDsc> BsnDscs { get; set; }
        
        public virtual ICollection<BsnDscTemp> BsnDscTemps { get; set; }
        
        [Key]
        [Description("Entreprise")]
        [Column("CD_ENTP_BSN__ENTREPRISE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Entreprise { get; set; }
        
    }
}
