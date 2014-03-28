using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_OA",Schema="OA")]
    public partial class OaCdType
    {
        public virtual ICollection<OaDsc> OaDscs { get; set; }
        
        public virtual ICollection<OaDscTemp> OaDscTemps { get; set; }
        
        [Key]
        [Description("Type")]
        [Column("CD_TYPE_OA__TYPE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Type { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TYPE_OA__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
