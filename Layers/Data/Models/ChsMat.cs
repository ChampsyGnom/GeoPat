using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MAT_CHS",Schema="CHS")]
    public partial class ChsMat
    {
        [Key]
        [Description("Matériaux")]
        [Column("MAT",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Mat { get; set; }
        
        [Description("Nature de matériaux")]
        [Column("CD_MAT_CHS__CODE",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String CdMatChsCode { get; set; }
        
    }
}
