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
        public virtual InfCdVoie InfCdVoie {get;set;}
        
        public virtual InfChaussee InfChaussee {get;set;}
        
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
        [Column("CL_VOIE_INF__ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Num Voie total")]
        [Column("CL_VOIE_INF__NUM_VNR",Order=4)]
        [Required()]
        public Int64 NumVnr { get; set; }
        
        [Description("Fin")]
        [Column("CL_VOIE_INF__ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Numéro Voie")]
        [Column("CL_VOIE_INF__NUM",Order=6)]
        public Nullable<Int64> Num { get; set; }
        
        [Description("Nbre de voies")]
        [Column("CL_VOIE_INF__NBRE",Order=7)]
        public Nullable<Int64> Nbre { get; set; }
        
        [Description("Nbre Voie total")]
        [Column("CL_VOIE_INF__NBRE_VNR",Order=8)]
        [Required()]
        public Int64 NbreVnr { get; set; }
        
    }
}
