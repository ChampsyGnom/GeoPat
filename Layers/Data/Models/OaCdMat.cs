using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MAT_OA",Schema="OA")]
    public partial class OaCdMat
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        [Key]
        [Description("Matériaux")]
        [Column("CD_MAT_OA__MATERIAUX",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Materiaux { get; set; }
        
    }
}
