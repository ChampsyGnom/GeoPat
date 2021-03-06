using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CL_VOIE_INF",Schema="INF")]
    public partial class InfClVoie
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
        
        [Key]
        [Description("Num Voie total")]
        [Column("NUM_VNR",Order=4)]
        [Required()]
        public Int64 NumVnr { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Numéro Voie")]
        [Column("NUM",Order=6)]
        public Nullable<Int64> Num { get; set; }
        
        [Description("Nbre de voies")]
        [Column("NBRE",Order=7)]
        public Nullable<Int64> Nbre { get; set; }
        
        [Description("Nbre Voie total")]
        [Column("NBRE_VNR",Order=8)]
        [Required()]
        public Int64 NbreVnr { get; set; }
        
    }
}
