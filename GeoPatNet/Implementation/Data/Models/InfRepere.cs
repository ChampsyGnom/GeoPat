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
	[DisplayName("Repère")]
    [TableName("INF_REPERE")]
    [SchemaName("INF")]
    public class InfRepere : IInfRepere
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Abscisse")]
        [ColumnName("INF_REPERE__ABS_CUM")]
        [UniqueKey("INF_REPERE_UK_REF")]
        public Int64 AbsCum
        {
            get;
            set;
        }
        [DisplayName("Distance inter PR")]
        [ColumnName("INF_REPERE__INTER")]
        public Int64 Inter
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_REPERE__ID")]
        [PrimaryKey("INF_REPERE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_REPERE","JOIN_o755")]
        [UniqueKey("INF_REPERE_UK2")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° de PR")]
        [ColumnName("INF_REPERE__NUM")]
        [UniqueKey("INF_REPERE_UK2")]
        public Int64 Num
        {
            get;
            set;
        }


    }
}
