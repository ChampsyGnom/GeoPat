using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_DOC_OH",Schema="OH")]
    public partial class OhCdDoc
    {
        public virtual ICollection<OhDoc> OhDocs { get; set; }
        
        [Key]
        [Description("Code")]
        [Column("CD_DOC_OH__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("CD_DOC_OH__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Répertoire")]
        [Column("CD_DOC_OH__PATH",Order=2)]
        [MaxLength(255)] 
        public String Path { get; set; }
        
    }
}
