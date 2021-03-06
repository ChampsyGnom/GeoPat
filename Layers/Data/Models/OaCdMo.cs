using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MO_OA",Schema="OA")]
    public partial class OaCdMo
    {
        [Key]
        [Description("Maitre d'ouvrage")]
        [Column("MAITRE_OUVR",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String MaitreOuvr { get; set; }
        
    }
}
