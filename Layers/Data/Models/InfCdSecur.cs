using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SECUR_INF",Schema="INF")]
    public partial class InfCdSecur
    {
        public virtual ICollection<InfSecurite> InfSecurites { get; set; }
        
        [Key]
        [Description("Sécurité")]
        [Column("CD_SECUR_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Type { get; set; }
        
    }
}
