using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_BSN",Schema="BSN")]
    public partial class BsnClsDoc
    {
        public virtual BsnCls BsnCls {get;set;}
        
        public virtual BsnDoc BsnDoc {get;set;}
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_BSN__ID",Order=0)]
        [Required()]
        public Int64 ClsBsnId { get; set; }
        
        [Key]
        [Description("Id document")]
        [Column("DOC_BSN__ID",Order=1)]
        [Required()]
        public Int64 DocBsnId { get; set; }
        
        [Description("Document par défaut")]
        [Column("CLS_DOC_BSN__DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("CLS_DOC_BSN__DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
