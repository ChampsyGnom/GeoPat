using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_HIERARCHIE_OA",Schema="OA")]
    public partial class OaCdHierarchie
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        [Key]
        [Description("Caractère stratégique")]
        [Column("CD_HIERARCHIE_OA__HIERARCHIE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Hierarchie { get; set; }
        
    }
}
