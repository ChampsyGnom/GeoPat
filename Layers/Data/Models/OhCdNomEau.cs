using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_NOM_EAU_OH",Schema="OH")]
    public partial class OhCdNomEau
    {
        [Key]
        [Description("Nom cours d'eau")]
        [Column("NOM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
    }
}
