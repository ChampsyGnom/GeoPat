using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PRT_OH",Schema="OH")]
    public partial class OhPrt
    {
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_OH__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpOhIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("ID_PRT",Order=1)]
        [Required()]
        public Int64 IdPrt { get; set; }
        
        [Description("Partie")]
        [Column("LIBP",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libp { get; set; }
        
        [Description("N° Ordre")]
        [Column("ORDRE",Order=3)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
