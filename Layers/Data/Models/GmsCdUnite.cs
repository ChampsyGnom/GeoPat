using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_UNITE_GMS",Schema="GMS")]
    public partial class GmsCdUnite
    {
        [Key]
        [Description("Unité")]
        [Column("UNITE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Unite { get; set; }
        
    }
}
