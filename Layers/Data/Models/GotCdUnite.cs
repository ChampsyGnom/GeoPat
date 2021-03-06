using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_UNITE_GOT",Schema="GOT")]
    public partial class GotCdUnite
    {
        [Key]
        [Description("Unité")]
        [Column("UNITE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Unite { get; set; }
        
    }
}
