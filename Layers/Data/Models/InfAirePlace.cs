using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("AIRE__PLACE_INF",Schema="INF")]
    public partial class InfAirePlace
    {
        [Key]
        [Description("Type Parking")]
        [Column("CD_PLACE_INF__PARKING",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdPlaceInfParking { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Type Aire")]
        [Column("CD_AIRE_INF__TYPE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String CdAireInfType { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CHAUSSEE_INF__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String ChausseeInfSens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("AIRE_INF__ABS_DEB",Order=4)]
        [Required()]
        public Int64 AireInfAbsDeb { get; set; }
        
        [Description("Nbre de place")]
        [Column("NBRE",Order=5)]
        public Nullable<Int64> Nbre { get; set; }
        
    }
}
