using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("BM_PROFIL_TABLE",Schema="PRF")]
    public partial class PrfBmProfilTable
    {
        [Key]
        [Description("Profil")]
        [Column("BM_PROFIL__PROFIL",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String BmProfilProfil { get; set; }
        
        [Key]
        [Description("Nom")]
        [Column("BM_TABLE__NOM",Order=1)]
        [Required()]
        [MaxLength(30)] 
        public String BmTableNom { get; set; }
        
        [Description("Ecrire")]
        [Column("ECRIRE",Order=2)]
        [Required()]
        public Boolean Ecrire { get; set; }
        
        [Description("Importer")]
        [Column("IMPORTER",Order=3)]
        [Required()]
        public Boolean Importer { get; set; }
        
        [Description("Afficher")]
        [Column("AFFICHER",Order=4)]
        public Nullable<Boolean> Afficher { get; set; }
        
    }
}
