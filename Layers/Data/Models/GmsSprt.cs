using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SPRT_GMS",Schema="GMS")]
    public partial class GmsSprt
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GMS__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpGmsIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GMS__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtGmsIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("ID_SPRT",Order=2)]
        [Required()]
        public Int64 IdSprt { get; set; }
        
        [Description("Sous partie")]
        [Column("LIBS",Order=3)]
        [Required()]
        [MaxLength(500)] 
        public String Libs { get; set; }
        
        [Description("N° Ordre")]
        [Column("ORDRE",Order=4)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
