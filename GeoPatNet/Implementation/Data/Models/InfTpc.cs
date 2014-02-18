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
	[DisplayName("Terre plein central")]
    [TableName("INF_TPC")]
    [SchemaName("INF")]
    public class InfTpc : IInfTpc
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code TPC")]
        [ColumnName("INF_CD_TPC__ID")]
        public virtual InfCodeTpc InfCodeTpc
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_TPC__ABS_DEB")]
        [UniqueKey("INF_TPC_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_TPC__ABS_FIN")]
        public Int64 AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_TPC__ID")]
        [PrimaryKey("INF_TPC_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_TPC","JOIN_o760")]
        [UniqueKey("INF_TPC_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code TPC")]
        [ColumnName("INF_CD_TPC__ID")]
        [ForeignKey("INF_CD_TPC__INF_TPC","JOIN_o779")]
        [UniqueKey("INF_TPC_UK_REF")]
        public Int64 InfCodeTpcId
        {
            get;
            set;
        }
        [DisplayName("Largeur")]
        [ColumnName("INF_TPC__LARGEUR")]
        public Nullable<Double> Largeur
        {
            get;
            set;
        }


    }
}
