using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_PV_GOT",Schema="GOT")]
    public partial class GotCdTypePv
    {
        [Key]
        [Description("Type de PV")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Cycle")]
        [Column("CYCLE",Order=2)]
        public Nullable<Int64> Cycle { get; set; }
        
        [Description("Coût unitaire (€)")]
        [Column("COUT",Order=3)]
        public Nullable<Int64> Cout { get; set; }
        
    }
}
