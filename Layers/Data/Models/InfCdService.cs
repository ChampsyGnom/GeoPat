using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SERVICE_INF",Schema="INF")]
    public partial class InfCdService
    {
        [Key]
        [Description("Type Service")]
        [Column("SERVICE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Service { get; set; }
        
    }
}
