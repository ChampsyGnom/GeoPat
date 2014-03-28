using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONTRAINTE_BSN",Schema="BSN")]
    public partial class BsnCdContrainte
    {
        public virtual ICollection<BsnPrevision> BsnPrevisions { get; set; }
        
        [Key]
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_BSN__TYPE",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
    }
}
