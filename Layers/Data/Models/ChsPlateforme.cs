using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PLATEFORME_CHS",Schema="CHS")]
    public partial class ChsPlateforme
    {
        public virtual ChsCdPortance ChsCdPortance {get;set;}
        
        public virtual ChsCdMpa ChsCdMpa {get;set;}
        
        [Key]
        [Description("Liaison")]
        [Column("PLATEFORME_CHS__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("PLATEFORME_CHS__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("PLATEFORME_CHS__ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Valeur (MPa)")]
        [Column("CD_MPA_CHS__VALEUR",Order=3)]
        [Required()]
        public Int64 CdMpaChsValeur { get; set; }
        
        [Description("Classe portance")]
        [Column("CD_PORTANCE_CHS__CLASSE",Order=4)]
        [Required()]
        [MaxLength(6)] 
        public String CdPortanceChsClasse { get; set; }
        
        [Description("Fin")]
        [Column("PLATEFORME_CHS__ABS_FIN",Order=5)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
    }
}
