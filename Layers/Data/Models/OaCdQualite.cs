using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_QUALITE_OA",Schema="OA")]
    public partial class OaCdQualite
    {
        [Key]
        [Description("Note IQOA")]
        [Column("CD_IQOA_OA__NOTE_IQOA",Order=0)]
        [Required()]
        [MaxLength(3)] 
        public String CdIqoaOaNoteIqoa { get; set; }
        
        [Key]
        [Description("Niveau qualité")]
        [Column("QUALITE",Order=1)]
        [Required()]
        [MaxLength(25)] 
        public String Qualite { get; set; }
        
    }
}
