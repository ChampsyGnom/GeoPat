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
	[DisplayName("Aire prestataire")]
    [TableName("INF_AIRE_PRESTATAIRE")]
    [SchemaName("INF")]
    public class InfAirePrestataire 
    {
    	
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_AIRE__INF_AIRE_PRESTATAIRE",null)]
        [UniqueKey("INF_AIRE_PRESTATAIRE_UK_REF")]
        public virtual InfAire InfAire
        {
            get;
            set;
        }
        [DisplayName("Prestataire")]
        [ColumnName("INF_PRESTATAIRE__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_PRESTATAIRE__INF_AIRE_PRESTATAIRE",null)]
        [UniqueKey("INF_AIRE_PRESTATAIRE_UK_REF")]
        public virtual InfPrestataire InfPrestataire
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AIRE_PRESTATAIRE__ID")]
        [PrimaryKey("INF_AIRE_PRESTATAIRE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant aire")]
        [ColumnName("INF_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> InfAireId
        {
            get;
            set;
        }
        [DisplayName("Identifiant prestataire")]
        [ColumnName("INF_PRESTATAIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> InfPrestataireId
        {
            get;
            set;
        }


    }
}
