using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CHAPITRE_OH",Schema="OH")]
    public partial class OhCdChapitre
    {
        public virtual ICollection<OhCdLigne> OhCdLignes { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_OH__ID_CHAP",Order=0)]
        [Required()]
        public Int64 IdChap { get; set; }
        
        [Description("Libellé chapitre")]
        [Column("CD_CHAPITRE_OH__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre chapitre")]
        [Column("CD_CHAPITRE_OH__ORDRE_CHAP",Order=2)]
        [Required()]
        public Int64 OrdreChap { get; set; }
        
        [Description("Pondération")]
        [Column("CD_CHAPITRE_OH__PONDERATION",Order=3)]
        public Nullable<Int64> Ponderation { get; set; }
        
    }
}
