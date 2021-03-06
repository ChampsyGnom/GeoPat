using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_OA",Schema="OA")]
    public partial class OaCdType
    {
        [Key]
        [Description("Type")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Type { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
