using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TRAVAUX_EQP",Schema="EQP")]
    public partial class EqpTravaux
    {
        [Key]
        [Description("Type travaux")]
        [Column("CD_TRAVAUX_EQP__CODE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String CdTravauxEqpCode { get; set; }
        
        [Key]
        [Description("Nature travaux")]
        [Column("NATURE_TRAV_EQP__NATURE",Order=1)]
        [Required()]
        [MaxLength(100)] 
        public String NatureTravEqpNature { get; set; }
        
        [Key]
        [Description("Type d'équipement")]
        [Column("CD_TYPE_EQP__TYPE_EQUIP",Order=2)]
        [Required()]
        [MaxLength(6)] 
        public String CdTypeEqpTypeEquip { get; set; }
        
        [Key]
        [Description("Identifiant Travaux")]
        [Column("ID_TRAV",Order=3)]
        [Required()]
        public Int64 IdTrav { get; set; }
        
        [Description("Entreprise")]
        [Column("CD_ENTP_EQP__ENTREPRISE",Order=4)]
        [Required()]
        [MaxLength(60)] 
        public String CdEntpEqpEntreprise { get; set; }
        
        [Description("N° Ouvrage")]
        [Column("OUVRAGE",Order=5)]
        [MaxLength(30)] 
        public String Ouvrage { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=6)]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=7)]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Position")]
        [Column("POSITION",Order=8)]
        [MaxLength(60)] 
        public String Position { get; set; }
        
        [Description("du PR")]
        [Column("ABS_DEB",Order=9)]
        public Nullable<Int64> AbsDeb { get; set; }
        
        [Description("au PR")]
        [Column("ABS_FIN",Order=10)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date Réception")]
        [Column("DATE_RCP",Order=11)]
        public Nullable<DateTime> DateRcp { get; set; }
        
        [Description("Coût (€)")]
        [Column("COUT",Order=12)]
        public Nullable<Int64> Cout { get; set; }
        
        [Description("Fin de garantie")]
        [Column("DATE_FIN_GAR",Order=13)]
        public Nullable<DateTime> DateFinGar { get; set; }
        
        [Description("No Marché")]
        [Column("MARCHE",Order=14)]
        [MaxLength(25)] 
        public String Marche { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=15)]
        [MaxLength(500)] 
        public String Commentaire { get; set; }
        
    }
}
