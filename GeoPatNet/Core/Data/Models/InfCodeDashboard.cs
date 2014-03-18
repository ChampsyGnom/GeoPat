using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Code tableau de bord")]
    [TableName("INF_CD_DASHBOARD")]
    [SchemaName("INF")]
    public class InfCodeDashboard 
    {
    	
        [DisplayName("Tableau de bords")]
        public virtual ObservableCollection<InfDashboard> InfDashboards
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_DASHBOARD__CODE")]
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
        [ColumnName("INF_CD_DASHBOARD__ID")]
        [PrimaryKey("IDENTIFIANT_1")]
        [ForeignKeyAttribute("INF_CD_DASHBOARD__INF_DASHBOARD","JOIN_o975")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_DASHBOARD__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeDashboard ()
		{
            this.InfDashboards = new ObservableCollection<InfDashboard>();
		}

    }
}
