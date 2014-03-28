using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_SOUS_TYPE_OH",Schema="OH")]
    public partial class OhCdSousType
    {
        public virtual ICollection<OhDsc> OhDscs { get; set; }
        
        public virtual ICollection<OhDscTemp> OhDscTemps { get; set; }
        
        [Key]
        [Description("Sous type OH")]
        [Column("CD_SOUS_TYPE_OH__SOUS_TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String SousType { get; set; }
        
    }
}
