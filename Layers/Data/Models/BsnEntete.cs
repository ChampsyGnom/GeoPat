using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ENTETE_BSN",Schema="BSN")]
    public partial class BsnEntete
    {
        [Key]
        [Description("Identifiant Campagne")]
        [Column("CAMP_BSN__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampBsnIdCamp { get; set; }
        
        [Key]
        [Description("N° Bassin")]
        [Column("DSC_BSN__NUM_BSN",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String DscBsnNumBsn { get; set; }
        
        [Key]
        [Description("Identifiant Entête")]
        [Column("CD_ENTETE_BSN__ID_ENTETE",Order=2)]
        [Required()]
        public Int64 CdEnteteBsnIdEntete { get; set; }
        
        [Description("Valeur")]
        [Column("VALEUR",Order=3)]
        [MaxLength(250)] 
        public String Valeur { get; set; }
        
    }
}
