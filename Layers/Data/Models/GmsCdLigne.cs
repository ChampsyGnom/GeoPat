using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_LIGNE_GMS",Schema="GMS")]
    public partial class GmsCdLigne
    {
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_GMS__ID_CHAP",Order=0)]
        [Required()]
        public Int64 CdChapitreGmsIdChap { get; set; }
        
        [Key]
        [Description("Identifiant ligne")]
        [Column("ID_LIGNE",Order=1)]
        [Required()]
        public Int64 IdLigne { get; set; }
        
        [Description("Libellé Ligne")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre ligne")]
        [Column("ORDRE_LIGNE",Order=3)]
        public Nullable<Int64> OrdreLigne { get; set; }
        
    }
}
