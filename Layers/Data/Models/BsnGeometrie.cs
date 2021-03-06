using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("GEOMETRIE_BSN",Schema="BSN")]
    public partial class BsnGeometrie
    {
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Description("Surf. Bassin (m²)")]
        [Column("SURF",Order=1)]
        public Nullable<Double> Surf { get; set; }
        
        [Description("Prof. Bassin (m)")]
        [Column("PROF",Order=2)]
        public Nullable<Double> Prof { get; set; }
        
        [Description("Pente Talus (%)")]
        [Column("PENTE",Order=3)]
        public Nullable<Double> Pente { get; set; }
        
        [Description("Périmètre clôture (m)")]
        [Column("PERIMETRE",Order=4)]
        public Nullable<Double> Perimetre { get; set; }
        
    }
}
