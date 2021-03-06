using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CHAUSSEE_INF",Schema="INF")]
    public partial class InfChaussee
    {
        [Key]
        [Description("Liaison")]
        [Column("LIAISON_INF__LIAISON",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String LiaisonInfLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("SENS",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Début")]
        [Column("ABS_DEB",Order=2)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("Fin")]
        [Column("ABS_FIN",Order=3)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
        [Description("Libellé")]
        [Column("LIBELLE",Order=4)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
        [Description("Tenant")]
        [Column("TENANT",Order=5)]
        [MaxLength(60)] 
        public String Tenant { get; set; }
        
        [Description("Aboutissant")]
        [Column("ABOUT",Order=6)]
        [MaxLength(60)] 
        public String About { get; set; }
        
    }
}
