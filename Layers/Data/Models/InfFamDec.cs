using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("FAM_DEC_INF",Schema="INF")]
    public partial class InfFamDec
    {
        public virtual ICollection<InfCdDec> InfCdDecs { get; set; }
        
        [Key]
        [Description("Code famille")]
        [Column("FAM_DEC_INF__FAM_DEC",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String FamDec { get; set; }
        
        [Description("Libellé")]
        [Column("FAM_DEC_INF__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
