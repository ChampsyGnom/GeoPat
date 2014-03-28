using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_DOC_INF",Schema="INF")]
    public partial class InfCdDoc
    {
        public virtual ICollection<InfDoc> InfDocs { get; set; }
        
        [Key]
        [Description("Code document")]
        [Column("CD_DOC_INF__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Répertoire")]
        [Column("CD_DOC_INF__PATH",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String Path { get; set; }
        
        [Description("Libellé")]
        [Column("CD_DOC_INF__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
