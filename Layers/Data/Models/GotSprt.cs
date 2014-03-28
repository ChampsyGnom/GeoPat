using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SPRT_GOT",Schema="GOT")]
    public partial class GotSprt
    {
        public virtual GotPrt GotPrt {get;set;}
        
        public virtual ICollection<GotElt> GotElts { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GOT__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpGotIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GOT__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtGotIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant sous partie")]
        [Column("SPRT_GOT__ID_SPRT",Order=2)]
        [Required()]
        public Int64 IdSprt { get; set; }
        
        [Description("Sous Partie")]
        [Column("SPRT_GOT__LIBS",Order=3)]
        [Required()]
        [MaxLength(500)] 
        public String Libs { get; set; }
        
        [Description("N° Ordre")]
        [Column("SPRT_GOT__ORDRE",Order=4)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
