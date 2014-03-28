using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PRT_GOT",Schema="GOT")]
    public partial class GotPrt
    {
        public virtual GotGrp GotGrp {get;set;}
        
        public virtual ICollection<GotSprt> GotSprts { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GOT__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpGotIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GOT__ID_PRT",Order=1)]
        [Required()]
        public Int64 IdPrt { get; set; }
        
        [Description("Partie")]
        [Column("PRT_GOT__LIBP",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libp { get; set; }
        
        [Description("No Ordre")]
        [Column("PRT_GOT__ORDRE",Order=3)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
