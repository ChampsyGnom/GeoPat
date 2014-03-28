using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_CAR_CHS",Schema="CHS")]
    public partial class ChsCdFamCar
    {
        public virtual ICollection<ChsFamCar> ChsFamCars { get; set; }
        
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_CAR_CHS__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("CD_FAM_CAR_CHS__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Coefficient Agressivité Moyen")]
        [Column("CD_FAM_CAR_CHS__CAM",Order=2)]
        [Required()]
        public Double Cam { get; set; }
        
    }
}
