using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_APPUI_OA",Schema="OA")]
    public partial class OaCdAppui
    {
        [Key]
        [Description("Type d'appui")]
        [Column("APP",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String App { get; set; }
        
    }
}
