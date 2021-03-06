using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAT_CHS",Schema="CHS")]
    public partial class ChsCdMat
    {
        [Key]
        [Description("Nature de matériaux")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Code { get; set; }
        
    }
}
