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
	[DisplayName("Code occupant")]
    [TableName("INF_CD_OCCUPANT")]
    [SchemaName("INF")]
    public class InfCodeOccupant 
    {
    	
        [DisplayName("Occupations")]
        public virtual ObservableCollection<InfOccupation> InfOccupations
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_OCCUPANT__CODE")]
        [UniqueKey("INF_CD_OCCUPANT_UK_REF")]
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
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [PrimaryKey("INF_CD_OCCUPANT_PK")]
        [ForeignKeyAttribute("INF_CD_OCCUPANT__INF_OCCUPATION","JOIN_o963")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_OCCUPANT__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeOccupant ()
		{
            this.InfOccupations = new ObservableCollection<InfOccupation>();
		}

    }
}
