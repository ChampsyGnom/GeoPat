using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("SIM_DVP_DS",Schema="DS")]
    public partial class DsSimDvp
    {
        [Key]
        [Description("SIM_DVP_DS__ID")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("SIM_ETUDE_DS__ID")]
        [Column("SIM_ETUDE_DS__ID",Order=1)]
        [Required()]
        public Int64 SimEtudeDsId { get; set; }
        
        [Description("SIM_DVP_DS__LIBELLE")]
        [Column("LIBELLE",Order=2)]
        [MaxLength(100)] 
        public String Libelle { get; set; }
        
        [Description("SIM_DVP_DS__COULEUR")]
        [Column("COULEUR",Order=3)]
        [Required()]
        [MaxLength(12)] 
        public String Couleur { get; set; }
        
    }
}
