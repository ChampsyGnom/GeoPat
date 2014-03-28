using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAFIC_INF",Schema="INF")]
    public partial class InfTrafic
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
        [Description("Année")]
        [Column("TRAFIC_INF__ANNEE",Order=2)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Description("PL (%)")]
        [Column("TRAFIC_INF__PL",Order=3)]
        public Nullable<Double> Pl { get; set; }
        
        [Description("TMJA")]
        [Column("TRAFIC_INF__TMJA",Order=4)]
        public Nullable<Int64> Tmja { get; set; }
        
    }
}
