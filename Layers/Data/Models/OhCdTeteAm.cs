using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TETE_AM_OH",Schema="OH")]
    public partial class OhCdTeteAm
    {
        [Key]
        [Description("Tête amont")]
        [Column("TETE_AM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String TeteAm { get; set; }
        
    }
}
