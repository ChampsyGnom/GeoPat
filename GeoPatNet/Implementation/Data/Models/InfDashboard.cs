using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Tableau de bord")]
    [TableName("INF_DASHBOARD")]
    [SchemaName("INF")]
    public class InfDashboard : IInfDashboard
    {
    	
        [DisplayName("Code tableau de bord")]
        [ColumnName("INF_CD_DASHBOARD__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        public virtual InfCodeDashboard InfCodeDashboard
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_DASHBOARD__CODE")]
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
        [ColumnName("INF_DASHBOARD__ID")]
        [PrimaryKey("IDENTIFIANT_1")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant parent")]
        [ColumnName("INF_DASHBOARD__ID_PARENT")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> IdParent
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("INF_CD_DASHBOARD__ID")]
        [ForeignKey("INF_CD_DASHBOARD__INF_DASHBOARD","JOIN_o801")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfCodeDashboardId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_DASHBOARD__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Ordre")]
        [ColumnName("INF_DASHBOARD__ORDRE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Ordre
        {
            get;
            set;
        }


    }
}
