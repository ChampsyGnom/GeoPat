using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TREE_DS",Schema="DS")]
    public partial class DsTree
    {
        [Key]
        [Description("TREE_DS__ID")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("TREE_DS__LIBELLE")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(200)] 
        public String Libelle { get; set; }
        
    }
}
