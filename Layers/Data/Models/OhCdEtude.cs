using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ETUDE_OH",Schema="OH")]
    public partial class OhCdEtude
    {
        public virtual ICollection<OhInsp> OhInsps { get; set; }
        
        public virtual ICollection<OhInspTmp> OhInspTmps { get; set; }
        
        [Key]
        [Description("Etude-Expertise")]
        [Column("CD_ETUDE_OH__ETUDE",Order=0)]
        [Required()]
        [MaxLength(65)] 
        public String Etude { get; set; }
        
    }
}
