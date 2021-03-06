using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ETUDE_OA",Schema="OA")]
    public partial class OaCdEtude
    {
        [Key]
        [Description("Etude-Expertise")]
        [Column("ETUDE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Etude { get; set; }
        
    }
}
