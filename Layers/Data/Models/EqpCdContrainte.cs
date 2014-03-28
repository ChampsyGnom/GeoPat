using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONTRAINTE_EQP",Schema="EQP")]
    public partial class EqpCdContrainte
    {
        public virtual ICollection<EqpPrevision> EqpPrevisions { get; set; }
        
        [Key]
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_EQP__TYPE",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
    }
}
