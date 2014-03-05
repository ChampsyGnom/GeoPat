using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Tableau de bord")]
    [TableName("INF_DASHBOARD")]
    [SchemaName("INF")]
    public class InfDashboard 
    {
    	
        [DisplayName("Code tableau de bord")]
        [ColumnName("INF_CD_DASHBOARD__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_DASHBOARD__INF_DASHBOARD",null)]
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
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
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
