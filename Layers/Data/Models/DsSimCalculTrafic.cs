using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_CALCUL_TRAFIC_DS",Schema="DS")]
    public partial class DsSimCalculTrafic
    {
        [Key]
        [Description("SIM_CALCUL_TRAFIC_DS__ID")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("SIM_CALCUL_DS__ID")]
        [Column("SIM_CALCUL_DS__ID",Order=1)]
        [Required()]
        public Int64 SimCalculDsId { get; set; }
        
        [Description("SIM_ENTRETIEN_DS__ID")]
        [Column("SIM_ENTRETIEN_DS__ID",Order=2)]
        public Nullable<Int64> SimEntretienDsId { get; set; }
        
        [Description("SIM_DVP_DS__ID")]
        [Column("SIM_DVP_DS__ID",Order=3)]
        public Nullable<Int64> SimDvpDsId { get; set; }
        
        [Description("SIM_REC_DS__ID")]
        [Column("SIM_REC_DS__ID",Order=4)]
        public Nullable<Int64> SimRecDsId { get; set; }
        
        [Description("SIM_CALCUL_TRAFIC_DS__TRAFIC")]
        [Column("TRAFIC",Order=5)]
        [Required()]
        [MaxLength(10)] 
        public String Trafic { get; set; }
        
    }
}
