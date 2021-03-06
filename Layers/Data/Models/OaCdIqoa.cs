using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_IQOA_OA",Schema="OA")]
    public partial class OaCdIqoa
    {
        [Key]
        [Description("Note IQOA")]
        [Column("NOTE_IQOA",Order=0)]
        [Required()]
        [MaxLength(3)] 
        public String NoteIqoa { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=1)]
        [MaxLength(1000)] 
        public String Commentaire { get; set; }
        
    }
}
