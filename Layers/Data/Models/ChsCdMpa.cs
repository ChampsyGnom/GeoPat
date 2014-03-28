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
        [Key]
        [Description("Valeur (MPa)")]
        [Column("VALEUR",Order=0)]
        [Required()]
        public Int64 Valeur { get; set; }
        
    }
}
