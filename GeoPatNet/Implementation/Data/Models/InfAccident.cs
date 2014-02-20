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
	[DisplayName("Accident")]
    [TableName("INF_ACCIDENT")]
    [SchemaName("INF")]
    public class InfAccident : IInfAccident
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_ACCIDENT",null)]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Année")]
        [ColumnName("INF_ACCIDENT__ANNEE")]
        [UniqueKey("INF_ACCIDENT__UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Annee
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_ACCIDENT__ABS_DEB")]
        [UniqueKey("INF_ACCIDENT__UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_ACCIDENT__ABS_FIN")]
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
        [ColumnName("INF_ACCIDENT__ID")]
        [PrimaryKey("INF_ACCIDENT_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_ACCIDENT","JOIN_o766")]
        [UniqueKey("INF_ACCIDENT__UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Mois")]
        [ColumnName("INF_ACCIDENT__MOIS")]
        [UniqueKey("INF_ACCIDENT__UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 Mois
        {
            get;
            set;
        }
        [DisplayName("Nb accident")]
        [ColumnName("INF_ACCIDENT__NB")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> Nb
        {
            get;
            set;
        }
        [DisplayName("Nb accident par mois")]
        [ColumnName("INF_ACCIDENT__NB_MOIS")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(true)]
        public Nullable<Int64> NbMois
        {
            get;
            set;
        }


    }
}
