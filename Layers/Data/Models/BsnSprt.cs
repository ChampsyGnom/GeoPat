using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SPRT_BSN",Schema="BSN")]
    public partial class BsnSprt
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_BSN__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpBsnIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_BSN__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtBsnIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("ID_SPRT",Order=2)]
        [Required()]
        public Int64 IdSprt { get; set; }
        
        [Description("Sous Partie")]
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
