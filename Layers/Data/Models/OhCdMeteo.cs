using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_METEO_OH",Schema="OH")]
    public partial class OhCdMeteo
    {
        public virtual ICollection<OhInsp> OhInsps { get; set; }
        
        public virtual ICollection<OhInspTmp> OhInspTmps { get; set; }
        
        [Key]
        [Description("Météo")]
        [Column("CD_METEO_OH__METEO",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Meteo { get; set; }
        
    }
}
