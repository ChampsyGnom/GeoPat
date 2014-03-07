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
	[DisplayName("Aire service")]
    [TableName("INF_AIRE_SERVICE")]
    [SchemaName("INF")]
    public class InfAireService 
    {
    	
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_AIRE__INF_AIRE_SERVICE",null)]
        [UniqueKey("INF_AIRE_SERVICE_UK_REF")]
        public virtual InfAire InfAire
        {
            get;
            set;
        }
        [DisplayName("Type Service")]
        [ColumnName("INF_CD_SERVICE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_SERVICE__INF_AIRE_SERVICE",null)]
        [UniqueKey("INF_AIRE_SERVICE_UK_REF")]
        public virtual InfCodeService InfCodeService
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AIRE_SERVICE__ID")]
        [PrimaryKey("INF_AIRE_SERVICE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant aire")]
        [ColumnName("INF_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> InfAireId
        {
            get;
            set;
        }
        [DisplayName("Identifiant type service")]
        [ColumnName("INF_CD_SERVICE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> InfCodeServiceId
        {
            get;
            set;
        }


    }
}
