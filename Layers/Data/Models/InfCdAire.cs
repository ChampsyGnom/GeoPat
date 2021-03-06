using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_AIRE_INF",Schema="INF")]
    public partial class InfCdAire
    {
        [Key]
        [Description("Type Aire")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
