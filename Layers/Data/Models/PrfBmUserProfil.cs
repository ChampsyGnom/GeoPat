using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BM_USER_PROFIL",Schema="PRF")]
    public partial class PrfBmUserProfil
    {
        [Key]
        [Description("Domaine_Login")]
        [Column("BM_USER__LOGIN",Order=0)]
        [Required()]
        [MaxLength(50)] 
        public String BmUserLogin { get; set; }
        
        [Key]
        [Description("Profil")]
        [Column("BM_PROFIL__PROFIL",Order=1)]
        [Required()]
        [MaxLength(20)] 
        public String BmProfilProfil { get; set; }
        
    }
}
