using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ORIGIN_OH",Schema="OH")]
    public partial class OhCdOrigin
    {
        public virtual ICollection<OhHistoNote> OhHistoNotes { get; set; }
        
        [Key]
        [Description("Origine Note")]
        [Column("CD_ORIGIN_OH__ORIGINE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Origine { get; set; }
        
    }
}
