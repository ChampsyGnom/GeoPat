using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TECH_CHS",Schema="CHS")]
    public partial class ChsCdTech
    {
        public virtual ChsCdFamTech ChsCdFamTech {get;set;}
        
        public virtual ICollection<ChsPave> ChsPaves { get; set; }
        
        public virtual ICollection<ChsSousCouche> ChsSousCouches { get; set; }
        
        [Key]
        [Description("Famille technique")]
        [Column("CD_FAM_TECH_CHS__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String CdFamTechChsCode { get; set; }
        
        [Key]
        [Description("Technique")]
        [Column("CD_TECH_CHS__TECHNIQUE",Order=1)]
        [Required()]
        [MaxLength(12)] 
        public String Technique { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TECH_CHS__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Garantie (mois)")]
        [Column("CD_TECH_CHS__GARANTIE",Order=3)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_TECH_CHS__DVT",Order=4)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
