using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_EXT_BSN",Schema="BSN")]
    public partial class BsnCdExt
    {
        [Key]
        [Description("Exutoire")]
        [Column("TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Bassin")]
        [Column("IS_BSN",Order=1)]
        [Required()]
        public Boolean IsBsn { get; set; }
        
        [Description("Ouvrage hydraulique")]
        [Column("IS_OH",Order=2)]
        [Required()]
        public Boolean IsOh { get; set; }
        
    }
}
