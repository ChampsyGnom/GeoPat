using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_OCCUP_INF",Schema="INF")]
    public partial class InfCdOccup
    {
        public virtual ICollection<InfOccupation> InfOccupations { get; set; }
        
        [Key]
        [Description("Type Occupation")]
        [Column("CD_OCCUP_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
