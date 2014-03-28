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
        public virtual ICollection<BsnDsc> BsnDscs { get; set; }
        
        public virtual ICollection<BsnDscTemp> BsnDscTemps { get; set; }
        
        [Key]
        [Description("Exutoire")]
        [Column("CD_EXT_BSN__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Bassin")]
        [Column("CD_EXT_BSN__IS_BSN",Order=1)]
        [Required()]
        public Boolean IsBsn { get; set; }
        
        [Description("Ouvrage hydraulique")]
        [Column("CD_EXT_BSN__IS_OH",Order=2)]
        [Required()]
        public Boolean IsOh { get; set; }
        
    }
}
