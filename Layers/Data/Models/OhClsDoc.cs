using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_OH",Schema="OH")]
    public partial class OhClsDoc
    {
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_OH__ID",Order=0)]
        [Required()]
        public Int64 ClsOhId { get; set; }
        
        [Key]
        [Description("Id document")]
        [Column("DOC_OH__ID",Order=1)]
        [Required()]
        public Int64 DocOhId { get; set; }
        
        [Description("Document par défaut")]
        [Column("DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
