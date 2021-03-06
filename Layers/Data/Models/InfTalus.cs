using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TALUS_INF",Schema="INF")]
    public partial class InfTalus
    {
        [Key]
        [Description("Type Talus")]
        [Column("CD_TALUS_INF__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdTalusInfType { get; set; }
        
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
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=4)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("hauteur (m)")]
        [Column("HAUT",Order=5)]
        public Nullable<Double> Haut { get; set; }
        
    }
}
