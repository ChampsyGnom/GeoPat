using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ROLE__DSC_BSN",Schema="BSN")]
    public partial class BsnCdRoleDsc
    {
        public virtual BsnDsc BsnDsc {get;set;}
        
        public virtual BsnCdRole BsnCdRole {get;set;}
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Rôle")]
        [Column("CD_ROLE_BSN__ROLE",Order=1)]
        [Required()]
        [MaxLength(25)] 
        public String CdRoleBsnRole { get; set; }
        
    }
}
