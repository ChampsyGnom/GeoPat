using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("ARCHIVE_3_OA",Schema="OA")]
    public partial class OaArchive3
    {
        public virtual ICollection<OaDscArchive3> OaDscArchive3s { get; set; }
        
        [Key]
        [Description("Date Calcul")]
        [Column("ARCHIVE_3_OA__DATE_CALC",Order=0)]
        [Required()]
        public DateTime DateCalc { get; set; }
        
        [Description("Nbre Total OA")]
        [Column("ARCHIVE_3_OA__NBRE",Order=1)]
        [Required()]
        public Int64 Nbre { get; set; }
        
        [Description("Surf totale")]
        [Column("ARCHIVE_3_OA__SURF",Order=2)]
        [Required()]
        public Int64 Surf { get; set; }
        
        [Description("Etat 3x")]
        [Column("ARCHIVE_3_OA__ETAT_3X",Order=3)]
        [Required()]
        [MaxLength(3)] 
        public String Etat3x { get; set; }
        
        [Description("Délai")]
        [Column("ARCHIVE_3_OA__DELAI",Order=4)]
        public Nullable<Int64> Delai { get; set; }
        
        [Description("Etat Lolf")]
        [Column("ARCHIVE_3_OA__ETAT_LOLF",Order=5)]
        public Nullable<Double> EtatLolf { get; set; }
        
        [Description("Montant pénalité")]
        [Column("ARCHIVE_3_OA__MONTANT",Order=6)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Commentaire")]
        [Column("ARCHIVE_3_OA__OBSV",Order=7)]
        [MaxLength(255)] 
        public String Obsv { get; set; }
        
    }
}
