using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TR_DEC_INF",Schema="INF")]
    public partial class InfTrDec
    {
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Code famille")]
        [Column("FAM_DEC_INF__FAM_DEC",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String FamDecInfFamDec { get; set; }
        
        [Key]
        [Description("Code decoupage")]
        [Column("CD_DEC_INF__CD_DEC",Order=3)]
        [Required()]
        [MaxLength(15)] 
        public String CdDecInfCdDec { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
    }
}
