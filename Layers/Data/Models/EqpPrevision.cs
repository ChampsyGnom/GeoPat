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
        public virtual EqpBpu EqpBpu {get;set;}
        
        public virtual EqpCdType EqpCdType {get;set;}
        
        public virtual EqpCdContrainte EqpCdContrainte {get;set;}
        
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
        [Column("PREVISION_EQP__ID_PREV",Order=2)]
        [Required()]
        public Int64 IdPrev { get; set; }
        
        [Description("Contrainte exploit")]
        [Column("CD_CONTRAINTE_EQP__TYPE",Order=3)]
        [MaxLength(100)] 
        public String CdContrainteEqpType { get; set; }
        
        [Description("N° Ouvrage")]
        [Column("PREVISION_EQP__OUVRAGE",Order=4)]
        [MaxLength(30)] 
        public String Ouvrage { get; set; }
        
        [Description("Liaison")]
        [Column("PREVISION_EQP__LIAISON",Order=5)]
        [MaxLength(15)] 
        public String Liaison { get; set; }
        
        [Description("Sens")]
        [Column("PREVISION_EQP__SENS",Order=6)]
        [MaxLength(6)] 
        public String Sens { get; set; }
        
        [Description("Position")]
        [Column("PREVISION_EQP__POSITION",Order=7)]
        [MaxLength(60)] 
        public String Position { get; set; }
        
        [Description("du PR")]
        [Column("PREVISION_EQP__ABS_DEB",Order=8)]
        public Nullable<Int64> AbsDeb { get; set; }
        
        [Description("au PR")]
        [Column("PREVISION_EQP__ABS_FIN",Order=9)]
        public Nullable<Int64> AbsFin { get; set; }
        
        [Description("Date début")]
        [Column("PREVISION_EQP__DATE_DEBUT",Order=10)]
        [Required()]
        public DateTime DateDebut { get; set; }
        
        [Description("Coûts (€)")]
        [Column("PREVISION_EQP__MONTANT",Order=11)]
        public Nullable<Int64> Montant { get; set; }
        
        [Description("Date fin")]
        [Column("PREVISION_EQP__DATE_FIN",Order=12)]
        public Nullable<DateTime> DateFin { get; set; }
        
        [Description("Commentaire")]
        [Column("PREVISION_EQP__COMMENTAIRE",Order=13)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
        [Description("Réalisé")]
        [Column("PREVISION_EQP__REALISE",Order=14)]
        public Nullable<Boolean> Realise { get; set; }
        
    }
}
