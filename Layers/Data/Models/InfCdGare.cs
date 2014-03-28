using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_GARE_INF",Schema="INF")]
    public partial class InfCdGare
    {
        public virtual ICollection<InfGare> InfGares { get; set; }
        
        [Key]
        [Description("Type Gare")]
        [Column("CD_GARE_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
