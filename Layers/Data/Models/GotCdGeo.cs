using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_GEO_GOT",Schema="GOT")]
    public partial class GotCdGeo
    {
        [Key]
        [Description("Géologie")]
        [Column("GEOLOGIE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Geologie { get; set; }
        
    }
}
