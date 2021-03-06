using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NATURE_TRAV_OA",Schema="OA")]
    public partial class OaNatureTrav
    {
        [Key]
        [Description("Type Travaux")]
        [Column("CD_TRAVAUX_OA__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxOaCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String Nature { get; set; }
        
    }
}
