using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAT_CHS",Schema="CHS")]
    public partial class ChsCdMat
    {
        public virtual ICollection<ChsMat> ChsMats { get; set; }
        
        public virtual ICollection<ChsCdOrig> ChsCdOrigs { get; set; }
        
        [Key]
        [Description("Nature de matériaux")]
        [Column("CD_MAT_CHS__CODE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Code { get; set; }
        
    }
}
