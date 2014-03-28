using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CLS_GMS",Schema="GMS")]
    public partial class GmsCls
    {
        public virtual ICollection<GmsClsDoc> GmsClsDocs { get; set; }
        
        [Key]
        [Description("Identifiant du classeur(cpt)")]
        [Column("CLS_GMS__ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Table")]
        [Column("CLS_GMS__TABLE_NAME",Order=1)]
        [MaxLength(30)] 
        public String TableName { get; set; }
        
        [Description("Enregistrement")]
        [Column("CLS_GMS__KEY_VALUE",Order=2)]
        [MaxLength(100)] 
        public String KeyValue { get; set; }
        
    }
}
