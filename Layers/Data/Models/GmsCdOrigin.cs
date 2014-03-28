using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIGIN_GMS",Schema="GMS")]
    public partial class GmsCdOrigin
    {
        public virtual ICollection<GmsHistoNote> GmsHistoNotes { get; set; }
        
        [Key]
        [Description("Origine Note")]
        [Column("CD_ORIGIN_GMS__ORIGINE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Origine { get; set; }
        
    }
}
