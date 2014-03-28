using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONCLUSION_GMS",Schema="GMS")]
    public partial class GmsCdConclusion
    {
        public virtual ICollection<GmsCdConclusionInsp> GmsCdConclusionInsps { get; set; }
        
        public virtual ICollection<GmsCdConclusionInspTmp> GmsCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant Conclusion")]
        [Column("CD_CONCLUSION_GMS__ID_CONC",Order=0)]
        [Required()]
        public Int64 IdConc { get; set; }
        
        [Description("Libellé Conclusion")]
        [Column("CD_CONCLUSION_GMS__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre Conclusion")]
        [Column("CD_CONCLUSION_GMS__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
