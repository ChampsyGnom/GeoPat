using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_COMPOSANT_BSN",Schema="BSN")]
    public partial class BsnCdComposant
    {
        public virtual ICollection<BsnCdEntete> BsnCdEntetes { get; set; }
        
        [Key]
        [Description("Type Composant")]
        [Column("CD_COMPOSANT_BSN__TYPE_COMP",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String TypeComp { get; set; }
        
        [Description("Libellé")]
        [Column("CD_COMPOSANT_BSN__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
