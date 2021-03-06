using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MAT_DS",Schema="DS")]
    public partial class DsMat
    {
        [Key]
        [Description("MAT_DS__CODE")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("MAT_DS__LIBELLE")]
        [Column("LIBELLE",Order=1)]
        [Required()]
        [MaxLength(200)] 
        public String Libelle { get; set; }
        
        [Description("MAT_DS__AGR_X")]
        [Column("AGR_X",Order=2)]
        [MaxLength(15)] 
        public String AgrX { get; set; }
        
        [Description("MAT_DS__INDIC_X")]
        [Column("INDIC_X",Order=3)]
        [MaxLength(15)] 
        public String IndicX { get; set; }
        
        [Description("MAT_DS__AGR_Y")]
        [Column("AGR_Y",Order=4)]
        [MaxLength(15)] 
        public String AgrY { get; set; }
        
        [Description("MAT_DS__INDIC_Y")]
        [Column("INDIC_Y",Order=5)]
        [MaxLength(15)] 
        public String IndicY { get; set; }
        
    }
}
