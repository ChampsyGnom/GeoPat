using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIGIN_OA",Schema="OA")]
    public partial class OaCdOrigin
    {
        public virtual ICollection<OaHistoNote> OaHistoNotes { get; set; }
        
        [Key]
        [Description("Origine")]
        [Column("CD_ORIGIN_OA__ORIGINE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Origine { get; set; }
        
    }
}
