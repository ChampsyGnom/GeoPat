using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PON_DS",Schema="DS")]
    public partial class DsPon
    {
        [Key]
        [Description("PON_DS__CODE")]
        [Column("CODE",Order=0)]
        [Required()]
        [MaxLength(15)] 
        public String Code { get; set; }
        
        [Description("PON_DS__LIBELLE")]
        [Column("LIBELLE",Order=1)]
        [Required()]
        [MaxLength(200)] 
        public String Libelle { get; set; }
        
        [Description("PON_DS__AGR")]
        [Column("AGR",Order=2)]
        [MaxLength(15)] 
        public String Agr { get; set; }
        
    }
}
