using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MAT_PARAM_DS",Schema="DS")]
    public partial class DsMatParam
    {
        [Key]
        [Description("MAT_DS__CODE")]
        [Column("MAT_DS__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String MatDsCode { get; set; }
        
        [Key]
        [Description("MAT_PARAM_DS__X")]
        [Column("X",Order=1)]
        [Required()]
        public Int64 X { get; set; }
        
        [Key]
        [Description("MAT_PARAM_DS__Y")]
        [Column("Y",Order=2)]
        [Required()]
        public Int64 Y { get; set; }
        
        [Description("MAT_PARAM_DS__VALEUR")]
        [Column("VALEUR",Order=3)]
        [Required()]
        public Int64 Valeur { get; set; }
        
    }
}
