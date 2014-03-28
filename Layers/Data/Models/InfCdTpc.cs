using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TPC_INF",Schema="INF")]
    public partial class InfCdTpc
    {
        public virtual ICollection<InfTpc> InfTpcs { get; set; }
        
        [Key]
        [Description("Code type")]
        [Column("CD_TPC_INF__CODE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TPC_INF__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
