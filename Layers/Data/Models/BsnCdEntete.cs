using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ENTETE_BSN",Schema="BSN")]
    public partial class BsnCdEntete
    {
        public virtual BsnCdComposant BsnCdComposant {get;set;}
        
        public virtual ICollection<BsnEntete> BsnEntetes { get; set; }
        
        [Key]
        [Description("Identifiant Entête")]
        [Column("CD_ENTETE_BSN__ID_ENTETE",Order=0)]
        [Required()]
        public Int64 IdEntete { get; set; }
        
        [Description("Type Composant")]
        [Column("CD_COMPOSANT_BSN__TYPE_COMP",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String CdComposantBsnTypeComp { get; set; }
        
        [Description("Libellé Entête")]
        [Column("CD_ENTETE_BSN__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre Entête")]
        [Column("CD_ENTETE_BSN__ORDRE_ENT",Order=3)]
        [Required()]
        public Int64 OrdreEnt { get; set; }
        
        [Description("Guide")]
        [Column("CD_ENTETE_BSN__GUIDE",Order=4)]
        [MaxLength(500)] 
        public String Guide { get; set; }
        
    }
}
