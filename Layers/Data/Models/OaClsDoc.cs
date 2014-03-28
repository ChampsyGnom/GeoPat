using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_OA",Schema="OA")]
    public partial class OaClsDoc
    {
        public virtual OaCls OaCls {get;set;}
        
        public virtual OaDoc OaDoc {get;set;}
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_OA__ID",Order=0)]
        [Required()]
        public Int64 ClsOaId { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_OA__ID",Order=1)]
        [Required()]
        public Int64 DocOaId { get; set; }
        
        [Description("Document par défaut")]
        [Column("CLS_DOC_OA__DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("CLS_DOC_OA__DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
