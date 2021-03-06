using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FRANCH_EQP",Schema="EQP")]
    public partial class EqpCdFranch
    {
        [Key]
        [Description("Anti franchissement")]
        [Column("ANTI_FRANCH",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String AntiFranch { get; set; }
        
    }
}
