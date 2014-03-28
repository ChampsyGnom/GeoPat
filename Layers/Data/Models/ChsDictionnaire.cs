using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DICTIONNAIRE_CHS",Schema="CHS")]
    public partial class ChsDictionnaire
    {
        [Key]
        [Description("Nom")]
        [Column("DICTIONNAIRE_CHS__NOM",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String Nom { get; set; }
        
        [Description("Description")]
        [Column("DICTIONNAIRE_CHS__DESCRIPTION",Order=1)]
        [MaxLength(255)] 
        public String Description { get; set; }
        
        [Description("Définition")]
        [Column("DICTIONNAIRE_CHS__DEFINITION",Order=2)]
        [MaxLength(1000)] 
        public String Definition { get; set; }
        
        [Description("Mots clés")]
        [Column("DICTIONNAIRE_CHS__MOTSCLES",Order=3)]
        [MaxLength(255)] 
        public String Motscles { get; set; }
        
    }
}
