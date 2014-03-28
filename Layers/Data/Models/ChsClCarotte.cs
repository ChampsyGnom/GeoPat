using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CL_CAROTTE_CHS",Schema="CHS")]
    public partial class ChsClCarotte
    {
        public virtual ICollection<ChsDetailCarotte> ChsDetailCarottes { get; set; }
        
        public virtual ICollection<ChsExploitCarotte> ChsExploitCarottes { get; set; }
        
        public virtual ICollection<ChsClRoul> ChsClRouls { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("CL_CAROTTE_CHS__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("CL_CAROTTE_CHS__SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Key]
        [Description("Voie")]
        [Column("CL_CAROTTE_CHS__VOIE",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("CL_CAROTTE_CHS__ABS_DEB",Order=3)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("CL_CAROTTE_CHS__ABS_FIN",Order=4)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
    }
}
