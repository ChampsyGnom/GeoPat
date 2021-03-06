using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PAVE_VOIE_INF",Schema="INF")]
    public partial class InfPaveVoie
    {
        [Key]
        [Description("Type Voie")]
        [Column("CD_VOIE_INF__VOIE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String CdVoieInfVoie { get; set; }
        
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
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Largeur (m)")]
        [Column("LARGEUR",Order=5)]
        [Required()]
        public Double Largeur { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=6)]
        [Required()]
        public DateTime DateMs { get; set; }
        
    }
}
