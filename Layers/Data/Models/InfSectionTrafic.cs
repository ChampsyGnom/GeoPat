using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SECTION_TRAFIC_INF",Schema="INF")]
    public partial class InfSectionTrafic
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
        [Description("Début")]
        [Column("ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Classe de trafic")]
        [Column("CD_CLASS_TRAF_INF__CODE",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String CdClassTrafInfCode { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=4)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Tenant")]
        [Column("TENANT",Order=5)]
        [MaxLength(60)] 
        public String Tenant { get; set; }
        
        [Description("Aboutissant")]
        [Column("ABOUTIS",Order=6)]
        [MaxLength(60)] 
        public String Aboutis { get; set; }
        
    }
}
