using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_ENTP_CHS",Schema="CHS")]
    public partial class ChsCdEntp
    {
        public virtual ICollection<ChsPave> ChsPaves { get; set; }
        
        [Key]
        [Description("Entreprise")]
        [Column("CD_ENTP_CHS__ENTREPRISE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Entreprise { get; set; }
        
    }
}
