using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TRAVAUX_OH",Schema="OH")]
    public partial class OhCdTravaux
    {
        [Key]
        [Description("Type travaux")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Code { get; set; }
        
    }
}
