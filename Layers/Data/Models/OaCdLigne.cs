using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_LIGNE_OA",Schema="OA")]
    public partial class OaCdLigne
    {
        public virtual OaCdChapitre OaCdChapitre {get;set;}
        
        public virtual ICollection<OaSprtVst> OaSprtVsts { get; set; }
        
        [Key]
        [Description("Identifiant chapitre")]
        [Column("CD_CHAPITRE_OA__ID_CHAP",Order=0)]
        [Required()]
        public Int64 CdChapitreOaIdChap { get; set; }
        
        [Key]
        [Description("Identifiant ligne")]
        [Column("CD_LIGNE_OA__ID_LIGNE",Order=1)]
        [Required()]
        public Int64 IdLigne { get; set; }
        
        [Description("Libellé Ligne")]
        [Column("CD_LIGNE_OA__LIBELLE",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libelle { get; set; }
        
        [Description("N° ordre ligne")]
        [Column("CD_LIGNE_OA__ORDRE_LIGNE",Order=3)]
        [Required()]
        public Int64 OrdreLigne { get; set; }
        
    }
}
