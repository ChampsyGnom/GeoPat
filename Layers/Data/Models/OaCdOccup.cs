using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_OCCUP_OA",Schema="OA")]
    public partial class OaCdOccup
    {
        public virtual ICollection<OaOccupation> OaOccupations { get; set; }
        
        [Key]
        [Description("Type Occupation")]
        [Column("CD_OCCUP_OA__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
