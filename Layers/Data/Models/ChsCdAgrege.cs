using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_AGREGE_CHS",Schema="CHS")]
    public partial class ChsCdAgrege
    {
        [Key]
        [Description("Valeur")]
        [Column("VALEUR",Order=0)]
        [Required()]
        public Int64 Valeur { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(50)] 
        public String Libelle { get; set; }
        
        [Description("Couleur")]
        [Column("COULEUR",Order=2)]
        [MaxLength(15)] 
        public String Couleur { get; set; }
        
    }
}
