using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_ETUDE_DS",Schema="DS")]
    public partial class DsSimEtude
    {
        [Key]
        [Description("SIM_ETUDE_DS__ID")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("SIM_ETUDE_DS__LIBELLE")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("SIM_ETUDE_DS__ANNEE_MIN")]
        [Column("ANNEE_MIN",Order=2)]
        [Required()]
        public Int64 AnneeMin { get; set; }
        
        [Description("SIM_ETUDE_DS__ANNEE_MAX")]
        [Column("ANNEE_MAX",Order=3)]
        [Required()]
        public Int64 AnneeMax { get; set; }
        
        [Description("SIM_ETUDE_DS__ANNEE_MIN_CALCUL")]
        [Column("ANNEE_MIN_CALCUL",Order=4)]
        [Required()]
        public Int64 AnneeMinCalcul { get; set; }
        
        [Description("SIM_ETUDE_DS__ANNEE_MAX_CALCUL")]
        [Column("ANNEE_MAX_CALCUL",Order=5)]
        [Required()]
        public Int64 AnneeMaxCalcul { get; set; }
        
    }
}
