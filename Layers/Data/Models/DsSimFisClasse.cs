using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_FIS_CLASSE_DS",Schema="DS")]
    public partial class DsSimFisClasse
    {
        public virtual DsSimFis DsSimFis {get;set;}
        
        public virtual ICollection<DsSimFisValues> DsSimFisValuess { get; set; }
        
        [Key]
        [Description("SIM_FIS_DS__ID")]
        [Column("SIM_FIS_DS__ID",Order=0)]
        [Required()]
        public Int64 SimFisDsId { get; set; }
        
        [Key]
        [Description("SIM_FIS_CLASSE_DS__ID")]
        [Column("SIM_FIS_CLASSE_DS__ID",Order=1)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("SIM_FIS_CLASSE_DS__COULEUR")]
        [Column("SIM_FIS_CLASSE_DS__COULEUR",Order=2)]
        [Required()]
        [MaxLength(12)] 
        public String Couleur { get; set; }
        
        [Description("SIM_FIS_CLASSE_DS__PERCENT_MIN")]
        [Column("SIM_FIS_CLASSE_DS__PERCENT_MIN",Order=3)]
        [Required()]
        public Int64 PercentMin { get; set; }
        
        [Description("SIM_FIS_CLASSE_DS__PERCENT_MAX")]
        [Column("SIM_FIS_CLASSE_DS__PERCENT_MAX",Order=4)]
        [Required()]
        public Int64 PercentMax { get; set; }
        
    }
}
