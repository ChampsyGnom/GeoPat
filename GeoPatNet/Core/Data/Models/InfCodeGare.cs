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
	[DisplayName("Code gare")]
    [TableName("INF_CD_GARE")]
    [SchemaName("INF")]
    public class InfCodeGare 
    {
    	
        [DisplayName("Gares")]
        public virtual ObservableCollection<InfGare> InfGares
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_GARE__CODE")]
        [UniqueKey("INF_CD_GARE_UK_REF")]
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
        [ColumnName("INF_CD_GARE__ID")]
        [PrimaryKey("INF_CD_GARE_PK")]
        [ForeignKeyAttribute("INF_CD_GARE__INF_GARE","JOIN_o998")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_GARE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeGare ()
		{
            this.InfGares = new ObservableCollection<InfGare>();
		}

    }
}
