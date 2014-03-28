using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_GMS",Schema="GMS")]
    public partial class GmsCdFam
    {
        public virtual ICollection<GmsDsc> GmsDscs { get; set; }
        
        public virtual ICollection<GmsDscTemp> GmsDscTemps { get; set; }
        
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_GMS__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("CD_FAM_GMS__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
