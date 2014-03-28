using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_FAM_OH",Schema="OH")]
    public partial class OhCdFam
    {
        public virtual ICollection<OhDsc> OhDscs { get; set; }
        
        public virtual ICollection<OhDscTemp> OhDscTemps { get; set; }
        
        [Key]
        [Description("Famille")]
        [Column("CD_FAM_OH__FAMILLE",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String Famille { get; set; }
        
        [Description("Libellé")]
        [Column("CD_FAM_OH__LIBELLE",Order=1)]
        [MaxLength(60)] 
        public String Libelle { get; set; }
        
    }
}
