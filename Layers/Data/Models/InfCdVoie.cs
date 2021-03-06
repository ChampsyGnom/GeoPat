using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_VOIE_INF",Schema="INF")]
    public partial class InfCdVoie
    {
        [Key]
        [Description("Type Voie")]
        [Column("VOIE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Description("Position")]
        [Column("POSIT",Order=1)]
        [Required()]
        public Int64 Posit { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Roulable")]
        [Column("ROULABLE",Order=3)]
        public Nullable<Boolean> Roulable { get; set; }
        
    }
}
