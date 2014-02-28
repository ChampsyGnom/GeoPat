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
	[DisplayName("Parking aire")]
    [TableName("INF_CD_PARKING__INF_AIRE")]
    [SchemaName("INF")]
    public class InfCodeParkingInfAire : IInfCodeParkingInfAire
    {
    	
        [DisplayName("Type parking")]
        [ColumnName("INF_CD_PLACE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_PARKING__INF_AIRE2",null)]
        [UniqueKey("INF_CD_PARKING__INF_AIRE_UK_REF")]
        public virtual InfCodePlace InfCodePlace
        {
            get;
            set;
        }
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_PARKING__INF_AIRE",null)]
        [UniqueKey("INF_CD_PARKING__INF_AIRE_UK_REF")]
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
        [DisplayName("Identifiant code parking")]
        [ColumnName("INF_CD_PLACE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodePlaceId
        {
            get;
            set;
        }
        [DisplayName("Nombre de place")]
        [ColumnName("INF_CD_PARKING__INF_AIRE__NB_PLACE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> NbPlace
        {
            get;
            set;
        }


    }
}
