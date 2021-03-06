using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MODELE_WEB",Schema="WEB")]
    public partial class WebModele
    {
        [Key]
        [Description("Identifiant du modèle")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Code du type de modèle (SIG_REF_DETAIL SIG_REF_SCHEMA)")]
        [Column("CD_MODELE_WEB__CODE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String CdModeleWebCode { get; set; }
        
        [Description("Libellé du modèle")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
        [Description("Public")]
        [Column("IS_PUBLIC",Order=3)]
        public Nullable<Boolean> IsPublic { get; set; }
        
    }
}
