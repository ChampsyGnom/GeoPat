using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_REC_VALUES_DS",Schema="DS")]
    public partial class DsSimRecValues
    {
        [Key]
        [Description("SIM_REC_DS__ID")]
        [Column("SIM_REC_DS__ID",Order=0)]
        [Required()]
        public Int64 SimRecDsId { get; set; }
        
        [Key]
        [Description("SIM_REC_VALUES_DS__ANNEE")]
        [Column("ANNEE",Order=1)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("SIM_REC_VALUES_DS__VALEUR")]
        [Column("VALEUR",Order=2)]
        [Required()]
        public Int64 Valeur { get; set; }
        
    }
}
