using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PORTANCE_CHS",Schema="CHS")]
    public partial class ChsCdPortance
    {
        [Key]
        [Description("Classe portance")]
        [Column("CLASSE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Classe { get; set; }
        
    }
}
