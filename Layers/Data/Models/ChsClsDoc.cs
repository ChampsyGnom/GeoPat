using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_CHS",Schema="CHS")]
    public partial class ChsClsDoc
    {
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_CHS__ID",Order=0)]
        [Required()]
        public Int64 ClsChsId { get; set; }
        
        [Key]
        [Description("Identifiant document(cpt)")]
        [Column("DOC_CHS__ID",Order=1)]
        [Required()]
        public Int64 DocChsId { get; set; }
        
        [Description("Document par défaut")]
        [Column("DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
