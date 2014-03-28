using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_RISQUE_GOT",Schema="GOT")]
    public partial class GotCdRisque
    {
        public virtual ICollection<GotDsc> GotDscs { get; set; }
        
        public virtual ICollection<GotHistoNote> GotHistoNotes { get; set; }
        
        [Key]
        [Description("Note Risque")]
        [Column("CD_RISQUE_GOT__RISQUE",Order=0)]
        [Required()]
        [MaxLength(3)] 
        public String Risque { get; set; }
        
    }
}
