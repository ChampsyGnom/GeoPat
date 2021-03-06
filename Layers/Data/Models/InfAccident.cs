using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ACCIDENT_INF",Schema="INF")]
    public partial class InfAccident
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
        [Description("Année")]
        [Column("ANNEE",Order=2)]
        [Required()]
        public Int64 Annee { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Key]
        [Description("Mois")]
        [Column("MOIS",Order=4)]
        [Required()]
        public Int64 Mois { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Nbre Accidents")]
        [Column("NBR_ACC",Order=6)]
        public Nullable<Int64> NbrAcc { get; set; }
        
        [Description("AM")]
        [Column("NBR_ACC_MOIS",Order=7)]
        public Nullable<Int64> NbrAccMois { get; set; }
        
    }
}
