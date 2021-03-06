using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_CLASSE_SV_EQP",Schema="EQP")]
    public partial class EqpCdClasseSv
    {
        [Key]
        [Description("Classe du film")]
        [Column("CLASSE",Order=0)]
        [Required()]
        [MaxLength(5)] 
        public String Classe { get; set; }
        
    }
}
