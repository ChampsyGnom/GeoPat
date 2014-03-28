using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PR_OLD_INF",Schema="INF")]
    public partial class InfPrOld
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
        [Description("Numéro PR")]
        [Column("PR_OLD_INF__NUM",Order=2)]
        [Required()]
        public Int64 Num { get; set; }
        
        [Description("Inter PR")]
        [Column("PR_OLD_INF__INTER",Order=3)]
        [Required()]
        public Int64 Inter { get; set; }
        
        [Description("Abscisse cumulée")]
        [Column("PR_OLD_INF__ABS_CUM",Order=4)]
        public Nullable<Int64> AbsCum { get; set; }
        
    }
}
