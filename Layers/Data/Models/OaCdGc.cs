using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_GC_OA",Schema="OA")]
    public partial class OaCdGc
    {
        public virtual ICollection<OaEquipement> OaEquipements { get; set; }
        
        [Key]
        [Description("Garde-corps")]
        [Column("CD_GC_OA__GARDE_CORPS",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String GardeCorps { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_GC_OA__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_GC_OA__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
