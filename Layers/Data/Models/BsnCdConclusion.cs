using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONCLUSION_BSN",Schema="BSN")]
    public partial class BsnCdConclusion
    {
        public virtual ICollection<BsnCdConclusionInsp> BsnCdConclusionInsps { get; set; }
        
        public virtual ICollection<BsnCdConclusionInspTmp> BsnCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant Conclusion")]
        [Column("CD_CONCLUSION_BSN__ID_CONC",Order=0)]
        [Required()]
        public Int64 IdConc { get; set; }
        
        [Description("Libellé Conclusion")]
        [Column("CD_CONCLUSION_BSN__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° oredre Conclusion")]
        [Column("CD_CONCLUSION_BSN__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
