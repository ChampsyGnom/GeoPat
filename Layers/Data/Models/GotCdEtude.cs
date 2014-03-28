using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ETUDE_GOT",Schema="GOT")]
    public partial class GotCdEtude
    {
        public virtual ICollection<GotInsp> GotInsps { get; set; }
        
        public virtual ICollection<GotInspTmp> GotInspTmps { get; set; }
        
        [Key]
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_GOT__ETUDE",Order=0)]
        [Required()]
        [MaxLength(65)] 
        public String Etude { get; set; }
        
    }
}
