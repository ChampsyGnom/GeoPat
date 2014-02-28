using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Data.Infrastructure.Models;
using Emash.GeoPatNet.Data.Infrastructure.Attributes;
using Emash.GeoPatNet.Presentation.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
namespace Emash.GeoPatNet.Data.Implementation.Models
{
	[DisplayName("Prestataire Aire")]
    [TableName("INF_PRESTATAIRE__INF_AIRE")]
    [SchemaName("INF")]
    public class InfPrestataireInfAire : IInfPrestataireInfAire
    {
    	
        [DisplayName("Prestataire")]
        [ColumnName("INF_PRESTATAIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_PRESTATAIRE__INF_AIRE",null)]
        [UniqueKey("INF_PRESTATAIRE__INF_AIRE_UK_REF")]
        public virtual InfPrestataire InfPrestataire
        {
            get;
            set;
        }
        [DisplayName("Aires")]
        [ColumnName("INF_AIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_PRESTATAIRE__INF_AIRE2",null)]
        [UniqueKey("INF_PRESTATAIRE__INF_AIRE_UK_REF")]
        public virtual InfAire InfAire
        {
            get;
            set;
        }
        [DisplayName("Identifiant aire")]
        [ColumnName("INF_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfAireId
        {
            get;
            set;
        }
        [DisplayName("Identifiant prestataire")]
        [ColumnName("INF_PRESTATAIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfPrestataireId
        {
            get;
            set;
        }


    }
}
