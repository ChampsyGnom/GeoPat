using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SOUS_TYPE_BSN",Schema="BSN")]
    public partial class BsnCdSousType
    {
        [Key]
        [Description("Nature sensibilité")]
        [Column("NAT_SENSIB",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String NatSensib { get; set; }
        
    }
}
