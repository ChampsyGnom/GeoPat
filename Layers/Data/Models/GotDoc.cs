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
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code")]
        [Column("CD_DOC_GOT__CODE",Order=1)]
        [Required()]
        [MaxLength(15)] 
        public String CdDocGotCode { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("Réference(fichier)")]
        [Column("REF",Order=3)]
        [MaxLength(50)] 
        public String Ref { get; set; }
        
    }
}
