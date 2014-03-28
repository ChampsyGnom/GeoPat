using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_INF",Schema="INF")]
    public partial class InfClsDoc
    {
        public virtual InfDoc InfDoc {get;set;}
        
        public virtual InfCls InfCls {get;set;}
        
        [Key]
        [Description("Identificant(cpt)")]
        [Column("DOC_INF__ID",Order=0)]
        [Required()]
        public Int64 DocInfId { get; set; }
        
        [Key]
        [Description("Identifiant (cpt)")]
        [Column("CLS_INF__ID",Order=1)]
        [Required()]
        public Int64 ClsInfId { get; set; }
        
        [Description("Document par défaut")]
        [Column("CLS_DOC_INF__DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("CLS_DOC_INF__DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
