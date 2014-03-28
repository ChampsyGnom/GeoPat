using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_EQP",Schema="EQP")]
    public partial class EqpCls
    {
        public virtual ICollection<EqpClsDoc> EqpClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_EQP__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_EQP__TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_EQP__KEY_VALUE",Order=2)]
        [Required()]
        [MaxLength(1000)] 
        public String KeyValue { get; set; }
        
    }
}
