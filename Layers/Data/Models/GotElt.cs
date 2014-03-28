using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_GOT",Schema="GOT")]
    public partial class GotElt
    {
        public virtual GotSprt GotSprt {get;set;}
        
        public virtual ICollection<GotEltInsp> GotEltInsps { get; set; }
        
        public virtual ICollection<GotEltInspTmp> GotEltInspTmps { get; set; }
        
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
        public Int64 SprtGotIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant Elément")]
        [Column("ELT_GOT__ID_ELEM",Order=3)]
        [Required()]
        public Int64 IdElem { get; set; }
        
        [Description("Elément")]
        [Column("ELT_GOT__LIBE",Order=4)]
        [Required()]
        [MaxLength(500)] 
        public String Libe { get; set; }
        
        [Description("N° Ordre")]
        [Column("ELT_GOT__ORDRE",Order=5)]
        [Required()]
        public Int64 Ordre { get; set; }
        
        [Description("Aide à la saisie")]
        [Column("ELT_GOT__AIDE",Order=6)]
        [MaxLength(500)] 
        public String Aide { get; set; }
        
        [Description("Indice1")]
        [Column("ELT_GOT__INDICE1",Order=7)]
        [MaxLength(500)] 
        public String Indice1 { get; set; }
        
        [Description("Indice2")]
        [Column("ELT_GOT__INDICE2",Order=8)]
        [MaxLength(500)] 
        public String Indice2 { get; set; }
        
        [Description("Indice3")]
        [Column("ELT_GOT__INDICE3",Order=9)]
        [MaxLength(500)] 
        public String Indice3 { get; set; }
        
    }
}
