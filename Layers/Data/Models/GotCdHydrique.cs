using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_HYDRIQUE_GOT",Schema="GOT")]
    public partial class GotCdHydrique
    {
        public virtual ICollection<GotCouche> GotCouches { get; set; }
        
        [Key]
        [Description("Etat hydrique")]
        [Column("CD_HYDRIQUE_GOT__ETAT",Order=0)]
        [Required()]
        [MaxLength(25)] 
        public String Etat { get; set; }
        
    }
}
