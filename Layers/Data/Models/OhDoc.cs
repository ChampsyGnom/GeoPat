using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DOC_OH",Schema="OH")]
    public partial class OhDoc
    {
        public virtual OhCdDoc OhCdDoc {get;set;}
        
        public virtual ICollection<OhContact> OhContacts { get; set; }
        
        public virtual ICollection<OhClsDoc> OhClsDocs { get; set; }
        
        [Key]
        [Description("Id document")]
        [Column("DOC_OH__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code")]
        [Column("CD_DOC_OH__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDocOhCode { get; set; }
        
        [Description("Libellé")]
        [Column("DOC_OH__LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("Réference (fichier)")]
        [Column("DOC_OH__REF",Order=3)]
        [Required()]
        [MaxLength(50)] 
        public String Ref { get; set; }
        
    }
}
