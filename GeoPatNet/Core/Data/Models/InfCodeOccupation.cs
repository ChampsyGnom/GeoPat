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
	[DisplayName("Code occupation")]
    [TableName("INF_CD_OCCUPATION")]
    [SchemaName("INF")]
    public class InfCodeOccupation 
    {
    	
        [DisplayName("Occupations")]
        public virtual ObservableCollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_OCCUPATION__CODE")]
        [UniqueKey("INF_CD_OCCUPATION_UK_REF")]
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
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [PrimaryKey("INF_CD_OCCUPATION_PK")]
        [ForeignKeyAttribute("INF_CD_OCCUPATION__INF_OCCUPATION","JOIN_o967")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_OCCUPATION__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeOccupation ()
		{
            this.InfOccupations = new ObservableCollection<InfOccupation>();
		}

    }
}
