using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("LIAISON_INF",Schema="INF")]
    public partial class InfLiaison
    {
        [Key]
        [Description("Liaison")]
        [Column("LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Code")]
        [Column("CD_LIAISON_INF__CD_LIAISON",Order=1)]
        [Required()]
        [MaxLength(5)] 
        public String CdLiaisonInfCdLiaison { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
