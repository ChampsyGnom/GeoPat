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
	[DisplayName("Code bifurcation")]
    [TableName("INF_CD_BIFURCATION")]
    [SchemaName("INF")]
    public class InfCodeBifurcation 
    {
    	
        [DisplayName("Bifurcations")]
        public virtual ObservableCollection<InfBifurcation> InfBifurcations
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_BIFURCATION__CODE")]
        [UniqueKey("INF_CD_BIFURCATION__UK_REF")]
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
        [ColumnName("INF_CD_BIFURCATION__ID")]
        [PrimaryKey("INF_CD_BIFURCATION_PK")]
        [ForeignKeyAttribute("INF_CD_BIFURCATION__INF_BIFURCATION","JOIN_o996")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_BIFURCATION__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeBifurcation ()
		{
            this.InfBifurcations = new ObservableCollection<InfBifurcation>();
		}

    }
}
