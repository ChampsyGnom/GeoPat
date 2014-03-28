using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_QUALITE_OH",Schema="OH")]
    public partial class OhCdQualite
    {
        [Key]
        [Description("Niveau qualité")]
        [Column("QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
