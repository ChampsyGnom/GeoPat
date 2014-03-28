using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIG_CHS",Schema="CHS")]
    public partial class ChsCdOrig
    {
        public virtual ChsCdMat ChsCdMat {get;set;}
        
        public virtual ICollection<ChsFabCar> ChsFabCars { get; set; }
        
        [Key]
        [Description("Nature de matériaux")]
        [Column("CD_MAT_CHS__CODE",Order=0)]
        [Required()]
        [MaxLength(12)] 
        public String CdMatChsCode { get; set; }
        
        [Key]
        [Description("Type fabricant/carrière")]
        [Column("CD_ORIG_CHS__CODE",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String Code { get; set; }
        
    }
}
