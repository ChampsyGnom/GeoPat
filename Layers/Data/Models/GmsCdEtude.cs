using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ETUDE_GMS",Schema="GMS")]
    public partial class GmsCdEtude
    {
        public virtual ICollection<GmsInsp> GmsInsps { get; set; }
        
        public virtual ICollection<GmsInspTmp> GmsInspTmps { get; set; }
        
        [Key]
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_GMS__ETUDE",Order=0)]
        [Required()]
        [MaxLength(65)] 
        public String Etude { get; set; }
        
    }
}
