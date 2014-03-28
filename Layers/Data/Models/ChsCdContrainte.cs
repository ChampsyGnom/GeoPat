using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONTRAINTE_CHS",Schema="CHS")]
    public partial class ChsCdContrainte
    {
        [Key]
        [Description("Contrainte")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Type { get; set; }
        
    }
}
