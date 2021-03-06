using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MODELE_WEB__NODE_WEB",Schema="WEB")]
    public partial class WebModeleWebNode
    {
        [Key]
        [Description("Identifiant du noeud")]
        [Column("NODE_WEB__ID",Order=0)]
        [Required()]
        public Int64 NodeWebId { get; set; }
        
        [Key]
        [Description("Identifiant du modèle")]
        [Column("MODELE_WEB__ID",Order=1)]
        [Required()]
        public Int64 ModeleWebId { get; set; }
        
        [Description("Ordre de la couche dans la carte")]
        [Column("MAP_ORDER",Order=2)]
        public Nullable<Int64> MapOrder { get; set; }
        
        [Description("Style du noeud pour le modèle")]
        [Column("STYLE_WEB__ID",Order=3)]
        public Nullable<Int64> StyleWebId { get; set; }
        
    }
}
