using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_MOTS_RESERVE",Schema="MAPINFO")]
    public partial class MapinfoCdMotsReserve
    {
        [Key]
        [Description("Mot clef")]
        [Column("KEYWORD",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String Keyword { get; set; }
        
    }
}
