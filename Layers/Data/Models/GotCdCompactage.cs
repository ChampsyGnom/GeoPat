using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_COMPACTAGE_GOT",Schema="GOT")]
    public partial class GotCdCompactage
    {
        [Key]
        [Description("Compactage")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Code { get; set; }
        
    }
}
