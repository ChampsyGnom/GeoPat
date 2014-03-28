using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SENSIBLE_INF",Schema="INF")]
    public partial class InfSensible
    {
        public virtual InfCdSensible InfCdSensible {get;set;}
        
        public virtual InfChaussee InfChaussee {get;set;}
        
        [Key]
        [Description("Type sensible")]
        [Column("CD_SENSIBLE_INF__CODE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdSensibleInfCode { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("SENSIBLE_INF__ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("SENSIBLE_INF__ABS_FIN",Order=4)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Libelle")]
        [Column("SENSIBLE_INF__LIBELLE",Order=5)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
