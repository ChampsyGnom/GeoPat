using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("REPARTITION_TRAFIC_INF",Schema="INF")]
    public partial class InfRepartitionTrafic
    {
        public virtual InfChaussee InfChaussee {get;set;}
        
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
        [Description("PR debut")]
        [Column("REPARTITION_TRAFIC_INF__ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Année")]
        [Column("REPARTITION_TRAFIC_INF__ANNEE",Order=3)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("PR fin")]
        [Column("REPARTITION_TRAFIC_INF__ABS_FIN",Order=4)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Répartition trafic PL (%)")]
        [Column("REPARTITION_TRAFIC_INF__P_PL",Order=5)]
        public Nullable<Int64> PPl { get; set; }
        
    }
}
