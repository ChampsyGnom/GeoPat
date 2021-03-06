using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TB_MODELE",Schema="MAPINFO")]
    public partial class MapinfoTbModele
    {
        [Key]
        [Description("Nom")]
        [Column("MODELE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Modele { get; set; }
        
        [Description("Ordre")]
        [Column("ORDRE",Order=1)]
        public Nullable<Int64> Ordre { get; set; }
        
        [Description("Couche MAPINFO")]
        [Column("LAYER_NAME",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String LayerName { get; set; }
        
        [Description("Fichier REF")]
        [Column("PATH",Order=3)]
        [Required()]
        [MaxLength(255)] 
        public String Path { get; set; }
        
        [Description("Type de modèle")]
        [Column("TYPE_MODELE",Order=4)]
        [Required()]
        public Int64 TypeModele { get; set; }
        
    }
}
