using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NE_ADMIN_CHS",Schema="CHS")]
    public partial class ChsNeAdmin
    {
        [Key]
        [Description("Liaison")]
        [Column("NE_ADMIN_CHS__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("NE_ADMIN_CHS__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("NE_ADMIN_CHS__ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("NE_ADMIN_CHS__ABS_FIN",Order=3)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Nbre Essieu Admissible")]
        [Column("NE_ADMIN_CHS__NE_ADMISS",Order=4)]
        public Nullable<Int64> NeAdmiss { get; set; }
        
        [Description("Date démarage NE")]
        [Column("NE_ADMIN_CHS__DATE_ADMISS",Order=5)]
        public Nullable<DateTime> DateAdmiss { get; set; }
        
    }
}
