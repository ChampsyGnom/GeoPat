using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("DSC__ARCHIVE_3_OA",Schema="OA")]
    public partial class OaDscArchive3
    {
        [Key]
        [Description("Date Calcul")]
        [Column("ARCHIVE_3_OA__DATE_CALC",Order=0)]
        [Required()]
        public DateTime Archive3OaDateCalc { get; set; }
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Description("Note 3x")]
        [Column("NOTE3X",Order=2)]
        [Required()]
        [MaxLength(3)] 
        public String Note3x { get; set; }
        
        [Description("Ouvrage écarté")]
        [Column("ECARTE",Order=3)]
        public Nullable<Boolean> Ecarte { get; set; }
        
    }
}
