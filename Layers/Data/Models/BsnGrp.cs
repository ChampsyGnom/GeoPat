using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("GRP_BSN",Schema="BSN")]
    public partial class BsnGrp
    {
        public virtual ICollection<BsnPrt> BsnPrts { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_BSN__ID_GRP",Order=0)]
        [Required()]
        public Int64 IdGrp { get; set; }
        
        [Description("Groupe")]
        [Column("GRP_BSN__LIBG",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libg { get; set; }
        
        [Description("No Ordre")]
        [Column("GRP_BSN__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
