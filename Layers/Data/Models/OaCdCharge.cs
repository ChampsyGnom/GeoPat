using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CHARGE_OA",Schema="OA")]
    public partial class OaCdCharge
    {
        [Key]
        [Description("Surcharge")]
        [Column("SURCHARGE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Surcharge { get; set; }
        
    }
}
