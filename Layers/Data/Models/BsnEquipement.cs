using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("EQUIPEMENT_BSN",Schema="BSN")]
    public partial class BsnEquipement
    {
        [Key]
        [Description("Famille EQP")]
        [Column("CD_FAMEQP_BSN__FAM",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String CdFameqpBsnFam { get; set; }
        
        [Key]
        [Description("Type EQP")]
        [Column("CD_TYPEQP_BSN__TYPE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String CdTypeqpBsnType { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=2)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Identification")]
        [Column("POSITION",Order=3)]
        [Required()]
        [MaxLength(60)] 
        public String Position { get; set; }
        
        [Description("Date MS")]
        [Column("DATE_MS",Order=4)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=5)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
    }
}
