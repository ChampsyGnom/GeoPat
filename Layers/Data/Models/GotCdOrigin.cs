using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIGIN_GOT",Schema="GOT")]
    public partial class GotCdOrigin
    {
        [Key]
        [Description("Origine Note")]
        [Column("ORIGINE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Origine { get; set; }
        
    }
}
