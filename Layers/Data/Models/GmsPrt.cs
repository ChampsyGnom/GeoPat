using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PRT_GMS",Schema="GMS")]
    public partial class GmsPrt
    {
        public virtual GmsGrp GmsGrp {get;set;}
        
        public virtual ICollection<GmsSprt> GmsSprts { get; set; }
        
        [Key]
        [Description("Identifiant Groupe")]
        [Column("GRP_GMS__ID_GRP",Order=0)]
        [Required()]
        public Int64 GrpGmsIdGrp { get; set; }
        
        [Key]
        [Description("Identifiant Partie")]
        [Column("PRT_GMS__ID_PRT",Order=1)]
        [Required()]
        public Int64 IdPrt { get; set; }
        
        [Description("Partie")]
        [Column("PRT_GMS__LIBP",Order=2)]
        [Required()]
        [MaxLength(500)] 
        public String Libp { get; set; }
        
        [Description("N° Ordre")]
        [Column("PRT_GMS__ORDRE",Order=3)]
        [Required()]
        public Int64 Ordre { get; set; }
        
    }
}
