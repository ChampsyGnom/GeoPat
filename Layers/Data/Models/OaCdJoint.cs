using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("CD_JOINT_OA",Schema="OA")]
    public partial class OaCdJoint
    {
        public virtual ICollection<OaJoint> OaJoints { get; set; }
        
        [Key]
        [Description("Joint")]
        [Column("CD_JOINT_OA__TYPE",Order=0)]
        [Required()]
        [MaxLength(60)] 
        public String Type { get; set; }
        
        [Description("Garantie")]
        [Column("CD_JOINT_OA__GARANTIE",Order=1)]
        public Nullable<Int64> Garantie { get; set; }
        
        [Description("Durée de vie (mois)")]
        [Column("CD_JOINT_OA__DVT",Order=2)]
        public Nullable<Int64> Dvt { get; set; }
        
    }
}
