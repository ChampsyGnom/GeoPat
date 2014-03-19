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
	[DisplayName("Type Service")]
    [TableName("INF_CD_SERVICE")]
    [SchemaName("INF")]
    public class InfCodeService 
    {
    	
        [DisplayName("Aire services")]
        public virtual ObservableCollection<InfAireService> InfAireServices
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_SERVICE__CODE")]
        [UniqueKey("INF_CD_SERVICE_UK_REF")]
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
        [ColumnName("INF_CD_SERVICE__ID")]
        [PrimaryKey("INF_CD_SERVICE_PK")]
        [ForeignKeyAttribute("INF_CD_SERVICE__INF_AIRE_SERVICE","JOIN_o986")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_SERVICE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeService ()
		{
            this.InfAireServices = new ObservableCollection<InfAireService>();
		}

    }
}
