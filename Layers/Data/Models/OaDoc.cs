using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DOC_OA",Schema="OA")]
    public partial class OaDoc
    {
        public virtual OaCdDoc OaCdDoc {get;set;}
        
        public virtual ICollection<OaContact> OaContacts { get; set; }
        
        public virtual ICollection<OaClsDoc> OaClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_OA__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code")]
        [Column("CD_DOC_OA__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDocOaCode { get; set; }
        
        [Description("Libellé")]
        [Column("DOC_OA__LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("Réference(fichier)")]
        [Column("DOC_OA__REF",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String Ref { get; set; }
        
    }
}
