using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_METEO_GMS",Schema="GMS")]
    public partial class GmsCdMeteo
    {
        public virtual ICollection<GmsInsp> GmsInsps { get; set; }
        
        public virtual ICollection<GmsInspTmp> GmsInspTmps { get; set; }
        
        [Key]
        [Description("Condition météo")]
        [Column("CD_METEO_GMS__METEO",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Meteo { get; set; }
        
    }
}
