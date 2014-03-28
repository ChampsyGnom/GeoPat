using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONTRAINTE_GMS",Schema="GMS")]
    public partial class GmsCdContrainte
    {
        public virtual ICollection<GmsPrevision> GmsPrevisions { get; set; }
        
        [Key]
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_GMS__TYPE",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
    }
}
