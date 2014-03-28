using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_DOC_EQP",Schema="EQP")]
    public partial class EqpClsDoc
    {
        public virtual EqpCls EqpCls {get;set;}
        
        public virtual EqpDoc EqpDoc {get;set;}
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_EQP__ID",Order=0)]
        [Required()]
        public Int64 ClsEqpId { get; set; }
        
        [Key]
        [Description("Id document")]
        [Column("DOC_EQP__ID",Order=1)]
        [Required()]
        public Int64 DocEqpId { get; set; }
        
        [Description("Document par défaut")]
        [Column("CLS_DOC_EQP__DEFAUT",Order=2)]
        public Nullable<Boolean> Defaut { get; set; }
        
        [Description("Dossier")]
        [Column("CLS_DOC_EQP__DOSSIER",Order=3)]
        [MaxLength(15)] 
        public String Dossier { get; set; }
        
    }
}
