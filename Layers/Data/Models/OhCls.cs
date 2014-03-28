using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_OH",Schema="OH")]
    public partial class OhCls
    {
        public virtual ICollection<OhClsDoc> OhClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_OH__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_OH__TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_OH__KEY_VALUE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String KeyValue { get; set; }
        
    }
}
