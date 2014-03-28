using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_QUALITE_GMS",Schema="GMS")]
    public partial class GmsCdQualite
    {
        public virtual ICollection<GmsSeuilQualite> GmsSeuilQualites { get; set; }
        
        public virtual ICollection<GmsDsc> GmsDscs { get; set; }
        
        [Key]
        [Description("Niveau qualité")]
        [Column("CD_QUALITE_GMS__QUALITE",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
