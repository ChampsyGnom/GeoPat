using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_CHS",Schema="CHS")]
    public partial class ChsCls
    {
        public virtual ICollection<ChsClsDoc> ChsClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_CHS__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_CHS__TABLE_NAME",Order=1)]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_CHS__KEY_VALUE",Order=2)]
        [MaxLength(100)] 
        public String KeyValue { get; set; }
        
    }
}
