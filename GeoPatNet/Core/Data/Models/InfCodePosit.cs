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
	[DisplayName("Code position")]
    [TableName("INF_CD_POSIT")]
    [SchemaName("INF")]
    public class InfCodePosit 
    {
    	
        [DisplayName("Eclairages")]
        public virtual ICollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Sécurités")]
        public virtual ICollection<InfSecurite> InfSecurites
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CD_POSIT__ID")]
        [PrimaryKey("INF_CD_POSIT_PK")]
        [ForeignKeyAttribute("INF_CD_POSIT__INF_ECLAIRAGE","JOIN_o877")]
        [ForeignKeyAttribute("INF_CD_POSIT__INF_SECURITE","JOIN_o879")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Ordre")]
        [ColumnName("INF_CD_POSIT__ORDRE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> Ordre
        {
            get;
            set;
        }
        [DisplayName("Position")]
        [ColumnName("INF_CD_POSIT__POSITION")]
        [UniqueKey("INF_CD_POSIT_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Position
        {
            get;
            set;
        }


    }
}
