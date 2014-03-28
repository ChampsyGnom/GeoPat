using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("GRP_OA",Schema="OA")]
    public partial class OaGrp
    {
        public virtual ICollection<OaPrt> OaPrts { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OA__ID_GRP",Order=0)]
        [Required()]
        public Int64 IdGrp { get; set; }
        
        [Description("Groupe")]
        [Column("GRP_OA__LIBG",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libg { get; set; }
        
        [Description("N° Ordre")]
        [Column("GRP_OA__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
