using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_POTEAU_CL_EQP",Schema="EQP")]
    public partial class EqpCdPoteauCl
    {
        [Key]
        [Description("Poteaux")]
        [Column("POTEAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Poteaux { get; set; }
        
    }
}
