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
        public virtual ICollection<OaAppuis> OaAppuiss { get; set; }
        
        [Key]
        [Description("Type d'appui")]
        [Column("CD_APPUI_OA__APP",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String App { get; set; }
        
    }
}
