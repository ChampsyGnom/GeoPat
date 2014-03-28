using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DOC_GMS",Schema="GMS")]
    public partial class GmsDoc
    {
        public virtual GmsCdDoc GmsCdDoc {get;set;}
        
        public virtual ICollection<GmsContact> GmsContacts { get; set; }
        
        public virtual ICollection<GmsClsDoc> GmsClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_GMS__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code")]
        [Column("CD_DOC_GMS__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDocGmsCode { get; set; }
        
        [Description("Libellé")]
        [Column("DOC_GMS__LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("Réference (fichier)")]
        [Column("DOC_GMS__REF",Order=3)]
        [MaxLength(50)] 
        public String Ref { get; set; }
        
    }
}
