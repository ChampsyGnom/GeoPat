using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("JOINT_OA",Schema="OA")]
    public partial class OaJoint
    {
        public virtual OaTablier OaTablier {get;set;}
        
        public virtual OaCdJoint OaCdJoint {get;set;}
        
        [Key]
        [Description("NumOA")]
        [Column("DSC_OA__NUM_OA",Order=0)]
        [Required()]
        [MaxLength(20)] 
        public String DscOaNumOa { get; set; }
        
        [Key]
        [Description("N° Tablier")]
        [Column("TABLIER_OA__NUM_TAB",Order=1)]
        [Required()]
        public Int64 TablierOaNumTab { get; set; }
        
        [Key]
        [Description("N° joint")]
        [Column("JOINT_OA__NUM_JOINT",Order=2)]
        [Required()]
        public Int64 NumJoint { get; set; }
        
        [Description("Joint")]
        [Column("CD_JOINT_OA__TYPE",Order=3)]
        [Required()]
        [MaxLength(60)] 
        public String CdJointOaType { get; set; }
        
        [Description("Date de MS")]
        [Column("JOINT_OA__DATE_MS",Order=4)]
        public Nullable<DateTime> DateMs { get; set; }
        
        [Description("Longueur joint")]
        [Column("JOINT_OA__LONGUEUR",Order=5)]
        public Nullable<Double> Longueur { get; set; }
        
        [Description("Commentaire")]
        [Column("JOINT_OA__COMMENTAIRE",Order=6)]
        [MaxLength(255)] 
        public String Commentaire { get; set; }
        
    }
}
