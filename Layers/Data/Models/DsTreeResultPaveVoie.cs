using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("TREE_RESULT_PAVE_VOIE_DS",Schema="DS")]
    public partial class DsTreeResultPaveVoie
    {
        [Key]
        [Description("TREE_DS__ID")]
        [Column("TREE_DS__ID",Order=0)]
        [Required()]
        public Int64 TreeDsId { get; set; }
        
        [Key]
        [Description("TREE_RESULT_DS__ID")]
        [Column("TREE_RESULT_DS__ID",Order=1)]
        [Required()]
        public Int64 TreeResultDsId { get; set; }
        
        [Key]
        [Description("TREE_RESULT_PAVE_DS__LIAISON")]
        [Column("TREE_RESULT_PAVE_DS__LIAISON",Order=2)]
        [Required()]
        [MaxLength(15)] 
        public String TreeResultPaveDsLiaison { get; set; }
        
        [Key]
        [Description("TREE_RESULT_PAVE_DS__SENS")]
        [Column("TREE_RESULT_PAVE_DS__SENS",Order=3)]
        [Required()]
        [MaxLength(6)] 
        public String TreeResultPaveDsSens { get; set; }
        
        [Key]
        [Description("TREE_RESULT_PAVE_DS__ABS_DEB")]
        [Column("TREE_RESULT_PAVE_DS__ABS_DEB",Order=4)]
        [Required()]
        public Int64 TreeResultPaveDsAbsDeb { get; set; }
        
        [Key]
        [Description("TREE_RESULT_PAVE_VOIE_DS__VOIE")]
        [Column("VOIE",Order=5)]
        [Required()]
        [MaxLength(6)] 
        public String Voie { get; set; }
        
        [Description("TREE_RESULT_PAVE_VOIE_DS__ABS_DEB")]
        [Column("ABS_DEB",Order=6)]
        [Required()]
        public Int64 AbsDeb { get; set; }
        
        [Description("TREE_RESULT_PAVE_VOIE_DS__ABS_FIN")]
        [Column("ABS_FIN",Order=7)]
        [Required()]
        public Int64 AbsFin { get; set; }
        
    }
}
