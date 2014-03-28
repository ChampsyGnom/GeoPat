using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ELT_OH",Schema="OH")]
    public partial class OhElt
    {
        public virtual OhSprt OhSprt {get;set;}
        
        public virtual ICollection<OhEltInsp> OhEltInsps { get; set; }
        
        public virtual ICollection<OhEltInspTmp> OhEltInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OH__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpOhIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_OH__ID_PRT",Order=1)]
        [Required()]
        public Int64 PrtOhIdPrt { get; set; }
        
        [Key]
        [Description("Identifiant Sous Partie")]
        [Column("SPRT_OH__ID_SPRT",Order=2)]
        [Required()]
        public Int64 SprtOhIdSprt { get; set; }
        
        [Key]
        [Description("Identifiant élément")]
        [Column("ELT_OH__ID_ELEM",Order=3)]
        [Required()]
        public Int64 IdElem { get; set; }
        
        [Description("Elément")]
        [Column("ELT_OH__LIBE",Order=4)]
        [Required()]
        [MaxLength(500)] 
        public String Libe { get; set; }
        
        [Description("N° Ordre")]
        [Column("ELT_OH__ORDRE",Order=5)]
        [Required()]
        public Int64 Ordre { get; set; }
        
        [Description("Aide à la saisie")]
        [Column("ELT_OH__AIDE",Order=6)]
        [MaxLength(500)] 
        public String Aide { get; set; }
        
        [Description("Indice1")]
        [Column("ELT_OH__INDICE1",Order=7)]
        [MaxLength(500)] 
        public String Indice1 { get; set; }
        
        [Description("Indice2")]
        [Column("ELT_OH__INDICE2",Order=8)]
        [MaxLength(500)] 
        public String Indice2 { get; set; }
        
        [Description("Indice3")]
        [Column("ELT_OH__INDICE3",Order=9)]
        [MaxLength(500)] 
        public String Indice3 { get; set; }
        
    }
}
