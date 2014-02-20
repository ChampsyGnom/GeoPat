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
	[DisplayName("Occupation")]
    [TableName("INF_OCCUPATION")]
    [SchemaName("INF")]
    public class InfOccupation : IInfOccupation
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        public virtual InfCodeOccupant InfCodeOccupant
        {
            get;
            set;
        }
        [DisplayName("Code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        public virtual InfCodeOccupation InfCodeOccupation
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_OCCUPATION__INFO")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date FG")]
        [ColumnName("INF_OCCUPATION__DATE_FG")]
        [ControlType(ControlType.Date)]
        [AllowNull(true)]
        public Nullable<DateTime> DateFg
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_OCCUPATION__DATE_MS")]
        [ControlType(ControlType.Date)]
        [AllowNull(true)]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_OCCUPATION__ABS_DEB")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_OCCUPATION__ABS_FIN")]
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
        [ColumnName("INF_OCCUPATION__ID")]
        [PrimaryKey("INF_OCCUPATION_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_OCCUPATION","JOIN_o773")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [ForeignKey("INF_CD_OCCUPANT__INF_OCCUPATION","JOIN_o794")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfCodeOccupantId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [ForeignKey("INF_CD_OCCUPATION__INF_OCCUPATION","JOIN_o797")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfCodeOccupationId
        {
            get;
            set;
        }
        [DisplayName("Traversé")]
        [ColumnName("INF_OCCUPATION__TRAVERSE")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> Traverse
        {
            get;
            set;
        }


    }
}
