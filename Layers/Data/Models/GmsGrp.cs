using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("GRP_GMS",Schema="GMS")]
    public partial class GmsGrp
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("ID_GRP",Order=0)]
        [Required()]
        public Int64 IdGrp { get; set; }
        
        [Description("Groupe")]
        [Column("LIBG",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libg { get; set; }
        
        [Description("N° Ordre")]
        [Column("ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
