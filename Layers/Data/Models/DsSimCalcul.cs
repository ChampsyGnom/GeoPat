using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_CALCUL_DS",Schema="DS")]
    public partial class DsSimCalcul
    {
        [Key]
        [Description("SIM_CALCUL_DS__ID")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("SIM_ETUDE_DS__ID")]
        [Column("SIM_ETUDE_DS__ID",Order=1)]
        [Required()]
        public Int64 SimEtudeDsId { get; set; }
        
        [Description("SIM_CALCUL_DS__LIBELLE")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("SIM_CALCUL_DS__COMMENT")]
        [Column("COMMENT",Order=3)]
        [MaxLength(2000)] 
        public String Comment { get; set; }
        
    }
}
