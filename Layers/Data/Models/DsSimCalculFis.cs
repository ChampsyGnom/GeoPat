using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_CALCUL_FIS_DS",Schema="DS")]
    public partial class DsSimCalculFis
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
        
    }
}
