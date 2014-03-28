using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SEUIL_QUALITE_GMS",Schema="GMS")]
    public partial class GmsSeuilQualite
    {
        public virtual GmsCdQualite GmsCdQualite {get;set;}
        
        [Key]
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_GMS__QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdQualiteGmsQualite { get; set; }
        
        [Key]
        [Description("Indice urgence")]
        [Column("SEUIL_QUALITE_GMS__INDICE_URGENCE",Order=1)]
        [Required()]
        [MaxLength(5)] 
        public String IndiceUrgence { get; set; }
        
    }
}
