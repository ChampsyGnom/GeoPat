using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_GOT",Schema="GOT")]
    public partial class GotCls
    {
        public virtual ICollection<GotClsDoc> GotClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_GOT__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_GOT__TABLE_NAME",Order=1)]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_GOT__KEY_VALUE",Order=2)]
        [MaxLength(100)] 
        public String KeyValue { get; set; }
        
    }
}
