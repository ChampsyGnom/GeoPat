using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_COMPOSANT_OH",Schema="OH")]
    public partial class OhCdComposant
    {
        public virtual ICollection<OhCdEntete> OhCdEntetes { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_COMPOSANT_OH__TYPE_COMP",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String TypeComp { get; set; }
        
        [Description("Libellé")]
        [Column("CD_COMPOSANT_OH__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
