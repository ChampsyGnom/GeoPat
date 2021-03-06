using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("AMENAGEMENT_INF",Schema="INF")]
    public partial class InfAmenagement
    {
        [Key]
        [Description("Aménagement")]
        [Column("CD_AMENAG_INF__TYPE_AMENAG",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdAmenagInfTypeAmenag { get; set; }
        
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
        [Description("Date début")]
        [Column("DATE_DEB",Order=3)]
        [Required()]
        public DateTime DateDeb { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=4)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Date Fin")]
        [Column("DATE_FIN",Order=5)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=6)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Coûts (k€)")]
        [Column("COUT",Order=7)]
        public Nullable<Int64> Cout { get; set; }
        
        [Description("Commentaire")]
        [Column("OBSERV",Order=8)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
