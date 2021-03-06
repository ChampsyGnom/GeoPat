using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_RESULT_DS",Schema="DS")]
    public partial class DsSimResult
    {
        [Key]
        [Description("SIM_CALCUL_TRAFIC_DS__ID")]
        [Column("SIM_CALCUL_TRAFIC_DS__ID",Order=0)]
        [Required()]
        public Int64 SimCalculTraficDsId { get; set; }
        
        [Key]
        [Description("SIM_FIS_DS__ID")]
        [Column("SIM_FIS_DS__ID",Order=1)]
        [Required()]
        public Int64 SimFisDsId { get; set; }
        
        [Key]
        [Description("SIM_RESULT_DS__LIAISON")]
        [Column("LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("SIM_RESULT_DS__SENS")]
        [Column("SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("SIM_RESULT_DS__ABS_DEB")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("SIM_RESULT_DS__ANNEE")]
        [Column("ANNEE",Order=5)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("SIM_RESULT_DS__ABS_FIN")]
        [Column("ABS_FIN",Order=6)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("SIM_RESULT_DS__DVP")]
        [Column("DVR",Order=7)]
        [Required()]
        public Int64 Dvr { get; set; }
        
        [Description("SIM_RESULT_DS__FIS")]
        [Column("FIS",Order=8)]
        [Required()]
        public Int64 Fis { get; set; }
        
        [Description("SIM_RESULT_DS__LINEAIRE")]
        [Column("LINEAIRE",Order=9)]
        [Required()]
        public Int64 Lineaire { get; set; }
        
        [Description("SIM_RESULT_DS__SURFACE")]
        [Column("SURFACE",Order=10)]
        [Required()]
        public Int64 Surface { get; set; }
        
        [Description("SIM_RESULT_DS__EPAISSEUR")]
        [Column("EPAISSEUR",Order=11)]
        [Required()]
        public Int64 Epaisseur { get; set; }
        
    }
}
