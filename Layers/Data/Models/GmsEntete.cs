using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ENTETE_GMS",Schema="GMS")]
    public partial class GmsEntete
    {
        [Key]
        [Description("Identifiant")]
        [Column("CAMP_GMS__ID_CAMP",Order=0)]
        [Required()]
        [MaxLength(100)] 
        public String CampGmsIdCamp { get; set; }
        
        [Key]
        [Description("No GMS")]
        [Column("DSC_GMS__NUM_GMS",Order=1)]
        [Required()]
        [MaxLength(17)] 
        public String DscGmsNumGms { get; set; }
        
        [Key]
        [Description("Identifiant Entête")]
        [Column("CD_ENTETE_GMS__ID_ENTETE",Order=2)]
        [Required()]
        public Int64 CdEnteteGmsIdEntete { get; set; }
        
        [Description("Valeur")]
        [Column("VALEUR",Order=3)]
        [MaxLength(250)] 
        public String Valeur { get; set; }
        
    }
}
