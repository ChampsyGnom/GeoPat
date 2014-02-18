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
	[DisplayName("Talus")]
    [TableName("INF_TALUS")]
    [SchemaName("INF")]
    public class InfTalus : IInfTalus
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code talus")]
        [ColumnName("INF_CD_TALUS__ID")]
        public virtual InfCodeTalus InfCodeTalus
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_TALUS__ABS_DEB")]
        [UniqueKey("INF_TALUS_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_TALUS__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [DisplayName("Hauteur")]
        [ColumnName("INF_TALUS__HAUTEUR")]
        public Nullable<Double> Hauteur
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_TALUS__ID")]
        [PrimaryKey("INF_TALUS_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_TALUS","JOIN_o759")]
        [UniqueKey("INF_TALUS_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code talus")]
        [ColumnName("INF_CD_TALUS__ID")]
        [ForeignKey("INF_CD_TALUS__INF_TALUS","JOIN_o778")]
        [UniqueKey("INF_TALUS_UK_REF")]
        public Int64 InfCodeTalusId
        {
            get;
            set;
        }


    }
}
