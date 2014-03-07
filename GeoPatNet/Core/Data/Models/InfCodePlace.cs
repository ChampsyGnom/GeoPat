using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Type parking")]
    [TableName("INF_CD_PLACE")]
    [SchemaName("INF")]
    public class InfCodePlace 
    {
    	
        [DisplayName("Aire parkings")]
        public virtual ICollection<InfAireParking> InfAireParkings
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_PLACE__CODE")]
        [UniqueKey("INF_CD_PLACE_UK_REF")]
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
        [ColumnName("INF_CD_PLACE__ID")]
        [PrimaryKey("INF_CD_PLACE_PK")]
        [ForeignKeyAttribute("INF_CD_PARKING__INF_AIRE_PARKING","JOIN_o895")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_PLACE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
