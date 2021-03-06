using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("NATURE_TRAV_OH",Schema="OH")]
    public partial class OhNatureTrav
    {
        [Key]
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_OH__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxOhCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String Nature { get; set; }
        
    }
}
