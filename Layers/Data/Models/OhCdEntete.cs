using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ENTETE_OH",Schema="OH")]
    public partial class OhCdEntete
    {
        [Key]
        [Description("Identifiant Entête")]
        [Column("ID_ENTETE",Order=0)]
        [Required()]
        public Int64 IdEntete { get; set; }
        
        [Description("Type")]
        [Column("CD_COMPOSANT_OH__TYPE_COMP",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String CdComposantOhTypeComp { get; set; }
        
        [Description("Libellé Entête")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre Entête")]
        [Column("ORDRE_ENT",Order=3)]
        [Required()]
        public Int64 OrdreEnt { get; set; }
        
        [Description("Guide")]
        [Column("GUIDE",Order=4)]
        [MaxLength(500)] 
        public String Guide { get; set; }
        
    }
}
