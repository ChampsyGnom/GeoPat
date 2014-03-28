using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_METEO_GOT",Schema="GOT")]
    public partial class GotCdMeteo
    {
        public virtual ICollection<GotInsp> GotInsps { get; set; }
        
        public virtual ICollection<GotInspTmp> GotInspTmps { get; set; }
        
        [Key]
        [Description("Condition météo")]
        [Column("CD_METEO_GOT__METEO",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Meteo { get; set; }
        
    }
}
