using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_APPUI_OA",Schema="OA")]
    public partial class OaCdFamAppui
    {
        [Key]
        [Description("Famille d'appuis")]
        [Column("FAM_APP",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String FamApp { get; set; }
        
    }
}
