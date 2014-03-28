using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_BE_OA",Schema="OA")]
    public partial class OaCdBe
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        [Key]
        [Description("Bureau d'étude")]
        [Column("CD_BE_OA__BUREAU",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Bureau { get; set; }
        
    }
}
