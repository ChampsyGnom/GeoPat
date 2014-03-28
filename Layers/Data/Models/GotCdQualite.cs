using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_QUALITE_GOT",Schema="GOT")]
    public partial class GotCdQualite
    {
        public virtual ICollection<GotDsc> GotDscs { get; set; }
        
        public virtual ICollection<GotSeuilQualite> GotSeuilQualites { get; set; }
        
        [Key]
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_GOT__QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
