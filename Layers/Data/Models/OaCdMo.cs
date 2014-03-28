using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MO_OA",Schema="OA")]
    public partial class OaCdMo
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        [Key]
        [Description("Maitre d'ouvrage")]
        [Column("CD_MO_OA__MAITRE_OUVR",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String MaitreOuvr { get; set; }
        
    }
}
