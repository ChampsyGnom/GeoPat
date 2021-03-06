using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SEUIL_QUALITE_BSN",Schema="BSN")]
    public partial class BsnSeuilQualite
    {
        [Key]
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_BSN__QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdQualiteBsnQualite { get; set; }
        
        [Key]
        [Description("Indice urgence")]
        [Column("INDICE_URGENCE",Order=1)]
        [Required()]
        [MaxLength(5)] 
        public String IndiceUrgence { get; set; }
        
    }
}
