using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TALUS_INF",Schema="INF")]
    public partial class InfCdTalus
    {
        public virtual ICollection<InfTalus> InfTaluss { get; set; }
        
        [Key]
        [Description("Type Talus")]
        [Column("CD_TALUS_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Type { get; set; }
        
    }
}
