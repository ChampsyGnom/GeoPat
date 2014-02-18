using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Section trafic")]
    [TableName("INF_SECTION_TRAFIC")]
    [SchemaName("INF")]
    public class InfSectionTrafic : IInfSectionTrafic
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Classe de trafic")]
        [ColumnName("INF_CD_TRAFIC__ID")]
        public virtual InfCodeTrafic InfCodeTrafic
        {
            get;
            set;
        }
        [DisplayName("Aboutissant")]
        [ColumnName("INF_SECTION_TRAFIC__ABOUT")]
        public String About
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_SECTION_TRAFIC__ABS_DEB")]
        [UniqueKey("INF_SECTION_TRAFIC_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_SECTION_TRAFIC__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_SECTION_TRAFIC__ID")]
        [PrimaryKey("INF_SECTION_TRAFIC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_SECTION_TRAFIC","JOIN_o756")]
        [UniqueKey("INF_SECTION_TRAFIC_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant classe trafic")]
        [ColumnName("INF_CD_TRAFIC__ID")]
        [ForeignKey("INF_CD_TRAFIC__INF_SECTION_TRAFIC","JOIN_o763")]
        [UniqueKey("INF_SECTION_TRAFIC_UK_REF")]
        public Int64 InfCodeTraficId
        {
            get;
            set;
        }
        [DisplayName("Tenant")]
        [ColumnName("INF_SECTION_TRAFIC__TENANT")]
        public String Tenant
        {
            get;
            set;
        }


    }
}
