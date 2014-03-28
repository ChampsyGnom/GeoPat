using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MATERIAU_GOT",Schema="GOT")]
    public partial class GotCdMateriau
    {
        public virtual ICollection<GotCouche> GotCouches { get; set; }
        
        [Key]
        [Description("Matériaux")]
        [Column("CD_MATERIAU_GOT__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
    }
}
