using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Section trafic")]
    [TableName("INF_SECTION_TRAFIC")]
    [SchemaName("INF")]
    public class InfSectionTrafic : IInfSectionTrafic
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_SECTION_TRAFIC",null)]
        [UniqueKey("INF_SECTION_TRAFIC_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Classe de trafic")]
        [ColumnName("INF_CD_TRAFIC__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_TRAFIC__INF_SECTION_TRAFIC",null)]
        [UniqueKey("INF_SECTION_TRAFIC_UK_REF")]
        public virtual InfCodeTrafic InfCodeTrafic
        {
            get;
            set;
        }
        [DisplayName("Aboutissant")]
        [ColumnName("INF_SECTION_TRAFIC__ABOUT")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String About
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_SECTION_TRAFIC__ABS_DEB")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_SECTION_TRAFIC__ABS_FIN")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_SECTION_TRAFIC__ID")]
        [PrimaryKey("INF_SECTION_TRAFIC_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant classe trafic")]
        [ColumnName("INF_CD_TRAFIC__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeTraficId
        {
            get;
            set;
        }
        [DisplayName("Tenant")]
        [ColumnName("INF_SECTION_TRAFIC__TENANT")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Tenant
        {
            get;
            set;
        }


    }
}
