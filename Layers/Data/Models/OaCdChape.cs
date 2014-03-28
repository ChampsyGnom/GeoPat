using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CHAPE_OA",Schema="OA")]
    public partial class OaCdChape
    {
        public virtual ICollection<OaTablier> OaTabliers { get; set; }
        
        [Key]
        [Description("Type chape d'étanchéité")]
        [Column("CD_CHAPE_OA__CHAPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Chape { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_CHAPE_OA__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_CHAPE_OA__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
