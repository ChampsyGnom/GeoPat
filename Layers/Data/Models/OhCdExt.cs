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
        [Key]
        [Description("Type exutoire")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Exutoire OH")]
        [Column("IS_OH",Order=1)]
        [Required()]
        public Boolean IsOh { get; set; }
        
        [Description("Exétoire Bassin")]
        [Column("IS_BSN",Order=2)]
        [Required()]
        public Boolean IsBsn { get; set; }
        
    }
}
