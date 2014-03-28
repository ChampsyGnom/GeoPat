using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TABLIER_OA",Schema="OA")]
    public partial class OaCdTablier
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        [Key]
        [Description("Type tablier")]
        [Column("CD_TABLIER_OA__TABLIER",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Tablier { get; set; }
        
    }
}
