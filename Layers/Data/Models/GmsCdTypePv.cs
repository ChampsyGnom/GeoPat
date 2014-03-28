using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_TYPE_PV_GMS",Schema="GMS")]
    public partial class GmsCdTypePv
    {
        public virtual ICollection<GmsCamp> GmsCamps { get; set; }
        
        [Key]
        [Description("Type de PV")]
        [Column("CD_TYPE_PV_GMS__CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("Libellé")]
        [Column("CD_TYPE_PV_GMS__LIBELLE",Order=1)]
        [Required()]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Cycle")]
        [Column("CD_TYPE_PV_GMS__CYCLE",Order=2)]
        public Nullable<Int64> Cycle { get; set; }
        
        [Description("Cout unitaire (€)")]
        [Column("CD_TYPE_PV_GMS__COUT",Order=3)]
        public Nullable<Int64> Cout { get; set; }
        
    }
}
