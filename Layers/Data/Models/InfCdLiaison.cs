using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_LIAISON_INF",Schema="INF")]
    public partial class InfCdLiaison
    {
        [Key]
        [Description("Code")]
        [Column("CD_LIAISON",Order=0)]
        [Required()]
        [MaxLength(5)] 
        public String CdLiaison { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
