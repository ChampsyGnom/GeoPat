using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_SV_EQP",Schema="EQP")]
    public partial class EqpCdFamSv
    {
        [Key]
        [Description("Famille")]
        [Column("FAMILLE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
