using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_GMS",Schema="GMS")]
    public partial class GmsClsDoc
    {
        public virtual GmsCls GmsCls {get;set;}
        
        public virtual GmsDoc GmsDoc {get;set;}
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_GMS__ID",Order=0)]
        [Required()]
        public Int64 ClsGmsId { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_GMS__ID",Order=1)]
        [Required()]
        public Int64 DocGmsId { get; set; }
        
        [Description("Document par défaut")]
        [Column("CLS_DOC_GMS__DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("CLS_DOC_GMS__DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
