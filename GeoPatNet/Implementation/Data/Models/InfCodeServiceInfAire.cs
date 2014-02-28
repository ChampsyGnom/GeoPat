using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Service aire")]
    [TableName("INF_CD_SERVICE__INF_AIRE")]
    [SchemaName("INF")]
    public class InfCodeServiceInfAire : IInfCodeServiceInfAire
    {
    	
        [DisplayName("Type Service")]
        [ColumnName("INF_CD_SERVICE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_SERVICE__INF_AIRE2",null)]
        [UniqueKey("INF_CD_SERVICE__INF_AIRE_UK_REF")]
        public virtual InfCodeService InfCodeService
        {
            get;
            set;
        }
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_SERVICE__INF_AIRE",null)]
        [UniqueKey("INF_CD_SERVICE__INF_AIRE_UK_REF")]
        public virtual InfAire InfAire
        {
            get;
            set;
        }
        [DisplayName("Identifiant aire")]
        [ColumnName("INF_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfAireId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code service")]
        [ColumnName("INF_CD_SERVICE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeServiceId
        {
            get;
            set;
        }


    }
}
