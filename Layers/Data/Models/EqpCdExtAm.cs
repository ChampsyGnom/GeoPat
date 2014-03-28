using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EXT_AM_EQP",Schema="EQP")]
    public partial class EqpCdExtAm
    {
        public virtual ICollection<EqpDscEs> EqpDscEss { get; set; }
        
        [Key]
        [Description("Extrémité début")]
        [Column("CD_EXT_AM_EQP__EXT_DEB",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String ExtDeb { get; set; }
        
    }
}
