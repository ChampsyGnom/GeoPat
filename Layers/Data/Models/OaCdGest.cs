using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_GEST_OA",Schema="OA")]
    public partial class OaCdGest
    {
        [Key]
        [Description("Gestionnaire")]
        [Column("GESTIONNAIRE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Gestionnaire { get; set; }
        
    }
}
