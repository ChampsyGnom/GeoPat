using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("PK Chantier")]
    [TableName("INF_PK")]
    [SchemaName("INF")]
    public class InfPk : IInfPk
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Abscisse")]
        [ColumnName("INF_PK__ABS_CUM")]
        [UniqueKey("INF_PK_PK_UK_REF")]
        public Int64 AbsCum
        {
            get;
            set;
        }
        [DisplayName("Distance inter PR")]
        [ColumnName("INF_PK__INTER")]
        public Int64 Inter
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PK__ID")]
        [PrimaryKey("INF_PK_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_PK","JOIN_o752")]
        [UniqueKey("INF_PK_PK_UK_REF")]
        [UniqueKey("INF_PK_PK_UK1")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° de PR")]
        [ColumnName("INF_PK__NUM")]
        [UniqueKey("INF_PK_PK_UK1")]
        public Int64 Num
        {
            get;
            set;
        }


    }
}
