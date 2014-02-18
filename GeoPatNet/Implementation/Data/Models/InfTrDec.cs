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
	[DisplayName("Tronçons découpage")]
    [TableName("INF_TR_DEC")]
    [SchemaName("INF")]
    public class InfTrDec : IInfTrDec
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code découpage")]
        [ColumnName("INF_CD_DEC__ID")]
        public virtual InfCodeDec InfCodeDec
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_TR_DEC__ABS_DEB")]
        [UniqueKey("INF_TR_DEC_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_TR_DEC__ABS_FIN")]
        public Int64 AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_TR_DEC__ID")]
        [PrimaryKey("INF_TR_DEC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_TR_DEC","JOIN_o761")]
        [UniqueKey("INF_TR_DEC_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code découpage")]
        [ColumnName("INF_CD_DEC__ID")]
        [ForeignKey("INF_CD_DEC__INF_TR_DEC","JOIN_o767")]
        [UniqueKey("INF_TR_DEC_UK_REF")]
        public Int64 InfCodeDecId
        {
            get;
            set;
        }


    }
}
