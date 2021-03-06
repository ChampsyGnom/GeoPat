using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("PREVISION_EQP",Schema="EQP")]
    public partial class EqpPrevision
    {
        [Key]
        [Description("Technique")]
        [Column("BPU_EQP__TECHN",Order=0)]
        [Required()]
        [MaxLength(250)] 
        public String BpuEqpTechn { get; set; }
        
        [Key]
        [Description("Type d'équipement")]
        [Column("CD_TYPE_EQP__TYPE_EQUIP",Order=1)]
        [Required()]
        [MaxLength(6)] 
        public String CdTypeEqpTypeEquip { get; set; }
        
        [Key]
        [Description("Identifiant Prévisions")]
        [Column("ID_PREV",Order=2)]
        [Required()]
        public Int64 IdPrev { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_EQP__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteEqpType { get; set; }
        
        [Description("N° Ouvrage")]
        [Column("OUVRAGE",Order=4)]
        [MaxLength(30)] 
        public String Ouvrage { get; set; }
        
        [Description("Liaison")]
        [Column("LIAISON",Order=5)]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("SENS",Order=6)]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Position")]
        [Column("POSITION",Order=7)]
        [MaxLength(60)] 
        public String Position { get; set; }
        
        [Description("du PR")]
        [Column("ABS_DEB",Order=8)]
        public Nullable<Int64> AbsDeb { get; set; }
        
        [Description("au PR")]
        [Column("ABS_FIN",Order=9)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date début")]
        [Column("DATE_DEBUT",Order=10)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Coûts (€)")]
        [Column("MONTANT",Order=11)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date fin")]
        [Column("DATE_FIN",Order=12)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Commentaire")]
        [Column("COMMENTAIRE",Order=13)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("REALISE",Order=14)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
