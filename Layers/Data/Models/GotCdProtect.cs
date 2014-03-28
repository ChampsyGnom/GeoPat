using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PROTECT_GOT",Schema="GOT")]
    public partial class GotCdProtect
    {
        public virtual ICollection<GotDsc> GotDscs { get; set; }
        
        public virtual ICollection<GotDscTemp> GotDscTemps { get; set; }
        
        [Key]
        [Description("Protections")]
        [Column("CD_PROTECT_GOT__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
