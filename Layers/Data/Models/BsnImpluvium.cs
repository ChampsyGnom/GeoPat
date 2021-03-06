using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("IMPLUVIUM_BSN",Schema="BSN")]
    public partial class BsnImpluvium
    {
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("SENS",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("PR début")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("PR fin")]
        [Column("ABS_FIN",Order=4)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Surface (ha)")]
        [Column("SURFACE",Order=5)]
        public Nullable<Double> Surface { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=6)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
    }
}
