using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code talus")]
    [TableName("INF_CD_TALUS")]
    [SchemaName("INF")]
    public class InfCodeTalus 
    {
    	
        [DisplayName("Taluss")]
        public virtual ICollection<InfTalus> InfTaluss
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_TALUS__CODE")]
        [UniqueKey("INF_CD_TALUS_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_TALUS__ID")]
        [PrimaryKey("INF_CD_TALUS_PK")]
        [ForeignKeyAttribute("INF_CD_TALUS__INF_TALUS","JOIN_o883")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_TALUS__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
