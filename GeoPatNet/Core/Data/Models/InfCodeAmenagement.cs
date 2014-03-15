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
	[DisplayName("Code aménagement")]
    [TableName("INF_CD_AMENAGEMENT")]
    [SchemaName("INF")]
    public class InfCodeAmenagement 
    {
    	
        [DisplayName("Aménagements")]
        public virtual ICollection<InfAmenagement> InfAmenagements
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_AMENAGEMENT__CODE")]
        [UniqueKey("INF_CD_AMENAGEMENT_UK_REF")]
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
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        [PrimaryKey("INF_CD_AMENAGEMENT_PK")]
        [ForeignKeyAttribute("INF_CD_AMENAGEMENT__INF_AMENAGEMENT","JOIN_o962")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_AMENAGEMENT__LIBELLE")]
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
