using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_FIS_VALUES_DS",Schema="DS")]
    public partial class DsSimFisValues
    {
        [Key]
        [Description("SIM_FIS_DS__ID")]
        [Column("SIM_FIS_DS__ID",Order=0)]
        [Required()]
        public Int64 SimFisDsId { get; set; }
        
        [Key]
        [Description("SIM_FIS_CLASSE_DS__ID")]
        [Column("SIM_FIS_CLASSE_DS__ID",Order=1)]
        [Required()]
        public Int64 SimFisClasseDsId { get; set; }
        
        [Key]
        [Description("SIM_FIS_VALUES_DS__ANNEE")]
        [Column("ANNEE",Order=2)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("SIM_FIS_VALUES_DS__VALEUR")]
        [Column("VALEUR",Order=3)]
        [Required()]
        public Int64 Valeur { get; set; }
        
    }
}
