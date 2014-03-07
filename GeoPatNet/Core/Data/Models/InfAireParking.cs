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
	[DisplayName("Aire parking")]
    [TableName("INF_AIRE_PARKING")]
    [SchemaName("INF")]
    public class InfAireParking 
    {
    	
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_AIRE__INF_AIRE_PARKING",null)]
        [UniqueKey("INF_AIRE_PARKING_UK_REF")]
        public virtual InfAire InfAire
        {
            get;
            set;
        }
        [DisplayName("Type parking")]
        [ColumnName("INF_CD_PLACE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_PARKING__INF_AIRE_PARKING",null)]
        [UniqueKey("INF_AIRE_PARKING_UK_REF")]
        public virtual InfCodePlace InfCodePlace
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AIRE_PARKING__ID")]
        [PrimaryKey("INF_AIRE_PARKING_PK")]
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
        [DisplayName("Identifiant type parking")]
        [ColumnName("INF_CD_PLACE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> InfCodePlaceId
        {
            get;
            set;
        }
        [DisplayName("Nombre de place")]
        [ColumnName("INF_AIRE_PARKING__NB_PLACE")]
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
