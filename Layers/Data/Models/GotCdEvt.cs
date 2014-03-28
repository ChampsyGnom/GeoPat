using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EVT_GOT",Schema="GOT")]
    public partial class GotCdEvt
    {
        public virtual ICollection<GotEvt> GotEvts { get; set; }
        
        [Key]
        [Description("Type événement")]
        [Column("CD_EVT_GOT__TYPE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Type { get; set; }
        
        [Description("Impact métier")]
        [Column("CD_EVT_GOT__IMPACT",Order=1)]
        public Nullable<Boolean> Impact { get; set; }
        
    }
}
