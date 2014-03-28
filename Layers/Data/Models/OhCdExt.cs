using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EXT_OH",Schema="OH")]
    public partial class OhCdExt
    {
        public virtual ICollection<OhDsc> OhDscs { get; set; }
        
        public virtual ICollection<OhDscTemp> OhDscTemps { get; set; }
        
        [Key]
        [Description("Type exutoire")]
        [Column("CD_EXT_OH__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Exutoire OH")]
        [Column("CD_EXT_OH__IS_OH",Order=1)]
        [Required()]
        public Boolean IsOh { get; set; }
        
        [Description("Exétoire Bassin")]
        [Column("CD_EXT_OH__IS_BSN",Order=2)]
        [Required()]
        public Boolean IsBsn { get; set; }
        
    }
}
