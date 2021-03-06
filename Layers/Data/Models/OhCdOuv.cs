using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_OUV_OH",Schema="OH")]
    public partial class OhCdOuv
    {
        [Key]
        [Description("Profil")]
        [Column("OUV",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Ouv { get; set; }
        
    }
}
