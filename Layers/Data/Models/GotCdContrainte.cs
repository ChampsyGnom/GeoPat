using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONTRAINTE_GOT",Schema="GOT")]
    public partial class GotCdContrainte
    {
        public virtual ICollection<GotPrevision> GotPrevisions { get; set; }
        
        [Key]
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_GOT__TYPE",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
    }
}
