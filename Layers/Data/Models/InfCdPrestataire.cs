using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PRESTATAIRE_INF",Schema="INF")]
    public partial class InfCdPrestataire
    {
        public virtual ICollection<InfPrestataire> InfPrestataires { get; set; }
        
        [Key]
        [Description("Type Prestataire")]
        [Column("CD_PRESTATAIRE_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
