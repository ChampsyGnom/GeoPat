using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FONDATION_EQP",Schema="EQP")]
    public partial class EqpCdFondation
    {
        [Key]
        [Description("Type fondation")]
        [Column("FONDATION",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Fondation { get; set; }
        
    }
}
