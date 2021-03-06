using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PRT_OA",Schema="OA")]
    public partial class OaPrt
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OA__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpOaIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("ID_PRT",Order=1)]
        [Required()]
        public Int64 IdPrt { get; set; }
        
        [Description("Partie")]
        [Column("LIBP",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libp { get; set; }
        
        [Description("No Ordre")]
        [Column("ORDRE",Order=3)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
