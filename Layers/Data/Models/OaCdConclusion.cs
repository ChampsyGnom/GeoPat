using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONCLUSION_OA",Schema="OA")]
    public partial class OaCdConclusion
    {
        public virtual ICollection<OaCdConclusionInsp> OaCdConclusionInsps { get; set; }
        
        public virtual ICollection<OaCdConclusionInspTmp> OaCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant conclusion")]
        [Column("CD_CONCLUSION_OA__ID_CONC",Order=0)]
        [Required()]
        public Int64 IdConc { get; set; }
        
        [Description("Libellé conclusion")]
        [Column("CD_CONCLUSION_OA__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre conclusion")]
        [Column("CD_CONCLUSION_OA__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
