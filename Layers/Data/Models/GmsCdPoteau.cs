using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_POTEAU_GMS",Schema="GMS")]
    public partial class GmsCdPoteau
    {
        public virtual ICollection<GmsDsc> GmsDscs { get; set; }
        
        public virtual ICollection<GmsDscTemp> GmsDscTemps { get; set; }
        
        [Key]
        [Description("Type Poteau")]
        [Column("CD_POTEAU_GMS__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_POTEAU_GMS__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_POTEAU_GMS__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
