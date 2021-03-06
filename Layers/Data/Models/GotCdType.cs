using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_GOT",Schema="GOT")]
    public partial class GotCdType
    {
        [Key]
        [Description("Type")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Type { get; set; }
        
    }
}
