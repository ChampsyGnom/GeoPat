using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BM_PROFIL",Schema="PRF")]
    public partial class PrfBmProfil
    {
        [Key]
        [Description("Profil")]
        [Column("PROFIL",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Profil { get; set; }
        
        [Description("Code schéma")]
        [Column("BM_SCHEMA__SCHEMA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String BmSchemaSchema { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
