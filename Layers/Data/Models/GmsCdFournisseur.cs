using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FOURNISSEUR_GMS",Schema="GMS")]
    public partial class GmsCdFournisseur
    {
        [Key]
        [Description("Fournisseur")]
        [Column("NOM",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Nom { get; set; }
        
    }
}
