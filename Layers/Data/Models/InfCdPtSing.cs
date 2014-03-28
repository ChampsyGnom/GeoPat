using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PT_SING_INF",Schema="INF")]
    public partial class InfCdPtSing
    {
        public virtual ICollection<InfPtSing> InfPtSings { get; set; }
        
        [Key]
        [Description("Code type")]
        [Column("CD_PT_SING_INF__CODE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("CD_PT_SING_INF__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
