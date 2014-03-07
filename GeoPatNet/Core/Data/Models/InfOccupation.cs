using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Occupation")]
    [TableName("INF_OCCUPATION")]
    [SchemaName("INF")]
    public class InfOccupation 
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_OCCUPATION",null)]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_OCCUPANT__INF_OCCUPATION",null)]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public virtual InfCodeOccupant InfCodeOccupant
        {
            get;
            set;
        }
        [DisplayName("Code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_OCCUPATION__INF_OCCUPATION",null)]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
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
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_OCCUPATION__ABS_FIN")]
        [LocationAttribute(LocationAttributeType.ReferenceFin)]
        [RangeValue(-999999999999,999999999999)]
        [RulePr("INF_CHAUSSEE__ID")]
        [ControlType(ControlType.Pr)]
        [RuleEmprise("INF_CHAUSSEE__ID")]
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
        [LocationAttribute(LocationAttributeType.ReferenceId)]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeOccupantId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
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
