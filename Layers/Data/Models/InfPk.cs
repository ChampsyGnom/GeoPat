using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PK_INF",Schema="INF")]
    public partial class InfPk
    {
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
        [Description("Abscisse cumulée")]
        [Column("ABS_CUM",Order=2)]
        [Required()]
        public Int64 AbsCum { get; set; }
        
        [Description("Numéro PK")]
        [Column("NUM",Order=3)]
        [Required()]
        public Int64 Num { get; set; }
        
        [Description("Inter PK")]
        [Column("INTER",Order=4)]
        [Required()]
        public Int64 Inter { get; set; }
        
    }
}
