using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CORRESPONDANCE_INF",Schema="INF")]
    public partial class InfCorrespondance
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
        [Description("Axe SAE")]
        [Column("AXE_SAE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String AxeSae { get; set; }
        
        [Key]
        [Description("Emplacement SAE")]
        [Column("EMPLACE_SAE",Order=3)]
        [Required()]
        [MaxLength(60)] 
        public String EmplaceSae { get; set; }
        
        [Key]
        [Description("Sens SAE")]
        [Column("SENS_SAE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String SensSae { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Début")]
        [Column("ABS_DEB",Order=6)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
    }
}
