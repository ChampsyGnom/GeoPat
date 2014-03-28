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
        public virtual ICollection<ChsAgrege> ChsAgreges { get; set; }
        
        [Key]
        [Description("Valeur")]
        [Column("CD_AGREGE_CHS__VALEUR",Order=0)]
        [Required()]
        public Int64 Valeur { get; set; }
        
        [Description("Libellé")]
        [Column("CD_AGREGE_CHS__LIBELLE",Order=1)]
        [MaxLength(50)] 
        public String Libelle { get; set; }
        
        [Description("Couleur")]
        [Column("CD_AGREGE_CHS__COULEUR",Order=2)]
        [MaxLength(15)] 
        public String Couleur { get; set; }
        
    }
}
