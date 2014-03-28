using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TECH_OA",Schema="OA")]
    public partial class OaCdTech
    {
        public virtual ICollection<OaTablier> OaTabliers { get; set; }
        
        [Key]
        [Description("Technique")]
        [Column("CD_TECH_OA__TECHNIQUE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Technique { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TECH_OA__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_TECH_OA__GARANTIE",Order=2)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_TECH_OA__DVT",Order=3)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
