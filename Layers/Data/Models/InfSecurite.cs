using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SECURITE_INF",Schema="INF")]
    public partial class InfSecurite
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
        [Description("Sécurité")]
        [Column("CD_SECUR_INF__TYPE",Order=2)]
        [Required()]
        [MaxLength(25)] 
        public String CdSecurInfType { get; set; }
        
        [Key]
        [Description("Position")]
        [Column("CD_POSIT_INF__POSIT",Order=3)]
        [Required()]
        [MaxLength(12)] 
        public String CdPositInfPosit { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        public Nullable<Int64> AbsFin { get; set; }
        
    }
}
