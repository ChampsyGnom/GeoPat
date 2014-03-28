using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CONCLUSION_GOT",Schema="GOT")]
    public partial class GotCdConclusion
    {
        public virtual ICollection<GotCdConclusionInsp> GotCdConclusionInsps { get; set; }
        
        public virtual ICollection<GotCdConclusionInspTmp> GotCdConclusionInspTmps { get; set; }
        
        [Key]
        [Description("Identifiant conclusion")]
        [Column("CD_CONCLUSION_GOT__ID_CONC",Order=0)]
        [Required()]
        public Int64 IdConc { get; set; }
        
        [Description("Libellé conclusion")]
        [Column("CD_CONCLUSION_GOT__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° Ordre conclusion")]
        [Column("CD_CONCLUSION_GOT__ORDRE",Order=2)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
