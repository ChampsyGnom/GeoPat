using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PARAMSIS",Schema="CHS")]
    public partial class ChsParamsis
    {
        [Key]
        [Description("ENTREE")]
        [Column("ENTREE",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Entree { get; set; }
        
        [Key]
        [Description("PARAMETRE")]
        [Column("PARAMETRE",Order=1)]
        [Required()]
        [MaxLength(50)] 
        public String Parametre { get; set; }
        
        [Key]
        [Description("TYPE")]
        [Column("TYPE",Order=2)]
        [Required()]
        [MaxLength(50)] 
        public String Type { get; set; }
        
        [Description("VALEUR")]
        [Column("VALEUR",Order=3)]
        [MaxLength(50)] 
        public String Valeur { get; set; }
        
    }
}
