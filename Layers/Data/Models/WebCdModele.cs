using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MODELE_WEB",Schema="WEB")]
    public partial class WebCdModele
    {
        public virtual ICollection<WebModele> WebModeles { get; set; }
        
        [Key]
        [Description("Code du type de modèle (SIG_REF_DETAIL SIG_REF_SCHEMA)")]
        [Column("CD_MODELE_WEB__CODE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Code { get; set; }
        
        [Description("Nom du type de modele (detail synoptique schématique)")]
        [Column("CD_MODELE_WEB__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
    }
}
