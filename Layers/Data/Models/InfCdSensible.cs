using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SENSIBLE_INF",Schema="INF")]
    public partial class InfCdSensible
    {
        [Key]
        [Description("Type sensible")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Code { get; set; }
        
    }
}
