using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code sensibilité")]
    [TableName("INF_CD_SENSIBLE")]
    [SchemaName("INF")]
    public class InfCodeSensible 
    {
    	
        [DisplayName("Sensibilités")]
        public virtual ICollection<InfSensible> InfSensibles
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_SENSIBLE__CODE")]
        [UniqueKey("INF_CD_SENSIBLE_UK_REF")]
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
        [ColumnName("INF_CD_SENSIBLE__ID")]
        [PrimaryKey("INF_CD_SENSIBLE_PK")]
        [ForeignKeyAttribute("INF_CD_SENSIBLE__INF_SENSIBLE","JOIN_o976")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_SENSIBLE__LIBELLE")]
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
