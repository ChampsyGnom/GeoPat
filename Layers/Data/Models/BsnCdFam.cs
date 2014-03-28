using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_BSN",Schema="BSN")]
    public partial class BsnCdFam
    {
        public virtual ICollection<BsnDsc> BsnDscs { get; set; }
        
        public virtual ICollection<BsnDscTemp> BsnDscTemps { get; set; }
        
        [Key]
        [Description("Dénomination")]
        [Column("CD_FAM_BSN__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("CD_FAM_BSN__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
