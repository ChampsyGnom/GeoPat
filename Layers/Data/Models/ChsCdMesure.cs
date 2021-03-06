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
        [Key]
        [Description("Code Agr")]
        [Column("AGR",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Agr { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Cycle de surveillance")]
        [Column("CYCLE",Order=2)]
        [Required()]
        public Int64 Cycle { get; set; }
        
        [Description("Prix Unitaire (km)")]
        [Column("PRIX",Order=3)]
        public Nullable<Int64> Prix { get; set; }
        
    }
}
