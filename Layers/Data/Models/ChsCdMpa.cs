using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MPA_CHS",Schema="CHS")]
    public partial class ChsCdMpa
    {
        public virtual ICollection<ChsPlateforme> ChsPlateformes { get; set; }
        
        [Key]
        [Description("Valeur (MPa)")]
        [Column("CD_MPA_CHS__VALEUR",Order=0)]
        [Required()]
        public Int64 Valeur { get; set; }
        
    }
}
