using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAT_OA",Schema="OA")]
    public partial class OaCdMat
    {
        [Key]
        [Description("Matériaux")]
        [Column("MATERIAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Materiaux { get; set; }
        
    }
}
