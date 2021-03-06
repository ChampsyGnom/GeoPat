using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("MAT_PAVE_CHS",Schema="CHS")]
    public partial class ChsMatPave
    {
        [Key]
        [Description("Couche")]
        [Column("CD_COU_CHS__COUCHE",Order=0)]
        [Required()]
        [MaxLength(14)] 
        public String CdCouChsCouche { get; set; }
        
        [Key]
        [Description("Date MS")]
        [Column("PAVE_CHS__DATE_MS",Order=1)]
        [Required()]
        public DateTime PaveChsDateMs { get; set; }
        
        [Key]
        [Description("Liaison")]
        [Column("PAVE_CHS__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String PaveChsLiaison { get; set; }
        
        [Key]
        [Description("Sens")]
        [Column("PAVE_CHS__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String PaveChsSens { get; set; }
        
        [Key]
        [Description("Début")]
        [Column("PAVE_CHS__ABS_DEB",Order=4)]
        [Required()]
        public Int64 PaveChsAbsDeb { get; set; }
        
        [Key]
        [Description("Fin")]
        [Column("PAVE_CHS__ABS_FIN",Order=5)]
        [Required()]
        public Int64 PaveChsAbsFin { get; set; }
        
        [Key]
        [Description("No Ordre")]
        [Column("NUM",Order=6)]
        [Required()]
        public Int64 Num { get; set; }
        
        [Description("Nature de matériaux")]
        [Column("CD_MAT_CHS__CODE",Order=7)]
        [Required()]
        [MaxLength(12)] 
        public String CdMatChsCode { get; set; }
        
        [Description("Type fabricant/carrière")]
        [Column("CD_ORIG_CHS__CODE",Order=8)]
        [Required()]
        [MaxLength(20)] 
        public String CdOrigChsCode { get; set; }
        
        [Description("Fabricant/carrières")]
        [Column("FAB_CAR_CHS__NOM",Order=9)]
        [Required()]
        [MaxLength(60)] 
        public String FabCarChsNom { get; set; }
        
        [Description("Matériaux")]
        [Column("MAT_CHS__MAT",Order=10)]
        [Required()]
        [MaxLength(60)] 
        public String MatChsMat { get; set; }
        
        [Description("Classe matériau")]
        [Column("CLASSE",Order=11)]
        [MaxLength(8)] 
        public String Classe { get; set; }
        
        [Description("Dosage")]
        [Column("DOSAGE",Order=12)]
        [MaxLength(50)] 
        public String Dosage { get; set; }
        
        [Description("Observation")]
        [Column("OBSERV",Order=13)]
        [MaxLength(255)] 
        public String Observ { get; set; }
        
    }
}
