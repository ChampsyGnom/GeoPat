using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("FAM_CAR_CHS",Schema="CHS")]
    public partial class ChsFamCar
    {
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_CAR_CHS__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdFamCarChsFamille { get; set; }
        
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
        [Description("Début")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Fin")]
        [Column("ABS_FIN",Order=4)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Structure progressive")]
        [Column("PROGRESSIVE",Order=5)]
        public Nullable<Boolean> Progressive { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=6)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
