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
	[DisplayName("Ancien repérage")]
    [TableName("INF_PR_OLD")]
    [SchemaName("INF")]
    public class InfPrOld : IInfPrOld
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Abscisse")]
        [ColumnName("INF_PR_OLD__ABS_CUM")]
        [UniqueKey("INF_PR_OLD_UK_REF")]
        public Int64 AbsCum
        {
            get;
            set;
        }
        [DisplayName("Distance inter PR")]
        [ColumnName("INF_PR_OLD__INTER")]
        public Int64 Inter
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PR_OLD__ID")]
        [PrimaryKey("INF_PR_OLD_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_PR_OLD","JOIN_o744")]
        [UniqueKey("INF_PR_OLD_UK_REF")]
        [UniqueKey("INF_PR_OLD_UK2")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° de PR")]
        [ColumnName("INF_PR_OLD__NUM")]
        [UniqueKey("INF_PR_OLD_UK2")]
        public Int64 Num
        {
            get;
            set;
        }


    }
}
