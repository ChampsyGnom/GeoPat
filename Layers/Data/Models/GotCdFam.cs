using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_GOT",Schema="GOT")]
    public partial class GotCdFam
    {
        [Key]
        [Description("Profil")]
        [Column("FAMILLE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
