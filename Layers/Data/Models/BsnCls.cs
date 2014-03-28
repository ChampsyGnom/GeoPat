using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_BSN",Schema="BSN")]
    public partial class BsnCls
    {
        public virtual ICollection<BsnClsDoc> BsnClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_BSN__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_BSN__TABLE_NAME",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_BSN__KEY_VALUE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String KeyValue { get; set; }
        
    }
}
