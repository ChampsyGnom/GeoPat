using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DOC_GOT",Schema="GOT")]
    public partial class GotDoc
    {
        public virtual GotCdDoc GotCdDoc {get;set;}
        
        public virtual ICollection<GotContact> GotContacts { get; set; }
        
        public virtual ICollection<GotClsDoc> GotClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_GOT__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code")]
        [Column("CD_DOC_GOT__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDocGotCode { get; set; }
        
        [Description("Libellé")]
        [Column("DOC_GOT__LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("Réference(fichier)")]
        [Column("DOC_GOT__REF",Order=3)]
        [MaxLength(50)] 
        public String Ref { get; set; }
        
    }
}
