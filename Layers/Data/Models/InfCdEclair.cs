using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ECLAIR_INF",Schema="INF")]
    public partial class InfCdEclair
    {
        public virtual ICollection<InfEclairage> InfEclairages { get; set; }
        
        [Key]
        [Description("Eclairage")]
        [Column("CD_ECLAIR_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Type { get; set; }
        
    }
}
