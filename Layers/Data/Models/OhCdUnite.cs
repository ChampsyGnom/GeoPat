using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_UNITE_OH",Schema="OH")]
    public partial class OhCdUnite
    {
        public virtual ICollection<OhBpu> OhBpus { get; set; }
        
        [Key]
        [Description("Unité")]
        [Column("CD_UNITE_OH__UNITE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Unite { get; set; }
        
    }
}
