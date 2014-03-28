using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CHAPITRE_GOT",Schema="GOT")]
    public partial class GotCdChapitre
    {
        public virtual ICollection<GotCdLigne> GotCdLignes { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_GOT__ID_CHAP",Order=0)]
        [Required()]
        public Int64 IdChap { get; set; }
        
        [Description("Libellé chapitre")]
        [Column("CD_CHAPITRE_GOT__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("Ordre")]
        [Column("CD_CHAPITRE_GOT__ORDRE_CHAP",Order=2)]
        [Required()]
        public Int64 OrdreChap { get; set; }
        
        [Description("Pondération")]
        [Column("CD_CHAPITRE_GOT__PONDERATION",Order=3)]
        public Nullable<Int64> Ponderation { get; set; }
        
    }
}
