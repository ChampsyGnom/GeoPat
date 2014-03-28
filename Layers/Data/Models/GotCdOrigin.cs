using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIGIN_GOT",Schema="GOT")]
    public partial class GotCdOrigin
    {
        public virtual ICollection<GotHistoNote> GotHistoNotes { get; set; }
        
        [Key]
        [Description("Origine Note")]
        [Column("CD_ORIGIN_GOT__ORIGINE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Origine { get; set; }
        
    }
}
