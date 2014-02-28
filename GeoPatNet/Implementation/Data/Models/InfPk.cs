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
	[DisplayName("PK Chantier")]
    [TableName("INF_PK")]
    [SchemaName("INF")]
    public class InfPk : IInfPk
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_PK",null)]
        [UniqueKey("INF_PK_PK_UK_REF")]
        [UniqueKey("INF_PK_PK_UK1")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Abscisse")]
        [ColumnName("INF_PK__ABS_CUM")]
        [UniqueKey("INF_PK_PK_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsCum
        {
            get;
            set;
        }
        [DisplayName("Distance inter PR")]
        [ColumnName("INF_PK__INTER")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Inter
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PK__ID")]
        [PrimaryKey("INF_PK_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° de PR")]
        [ColumnName("INF_PK__NUM")]
        [UniqueKey("INF_PK_PK_UK1")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Num
        {
            get;
            set;
        }


    }
}
