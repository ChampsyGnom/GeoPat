using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PT_SING_INF",Schema="INF")]
    public partial class InfPtSing
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
        [Description("Code type")]
        [Column("CD_PT_SING_INF__CODE",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String CdPtSingInfCode { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=4)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Nom d'usage")]
        [Column("NOM_USAGE",Order=5)]
        [MaxLength(60)] 
        public String NomUsage { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=6)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
    }
}
