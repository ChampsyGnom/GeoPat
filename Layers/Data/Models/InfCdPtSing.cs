using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_PT_SING_INF",Schema="INF")]
    public partial class InfCdPtSing
    {
        [Key]
        [Description("Code type")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(6)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
