using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MESURE_CHS",Schema="CHS")]
    public partial class ChsCdMesure
    {
        public virtual ICollection<ChsCdIndic> ChsCdIndics { get; set; }
        
        public virtual ICollection<ChsCamp> ChsCamps { get; set; }
        
        [Key]
        [Description("Code Agr")]
        [Column("CD_MESURE_CHS__AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Agr { get; set; }
        
        [Description("Libellé")]
        [Column("CD_MESURE_CHS__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Cycle de surveillance")]
        [Column("CD_MESURE_CHS__CYCLE",Order=2)]
        [Required()]
        public Int64 Cycle { get; set; }
        
        [Description("Prix Unitaire (km)")]
        [Column("CD_MESURE_CHS__PRIX",Order=3)]
        public Nullable<Int64> Prix { get; set; }
        
    }
}
