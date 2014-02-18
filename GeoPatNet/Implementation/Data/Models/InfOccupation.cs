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
	[DisplayName("Occupation")]
    [TableName("INF_OCCUPATION")]
    [SchemaName("INF")]
    public class InfOccupation : IInfOccupation
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        public virtual InfCodeOccupant InfCodeOccupant
        {
            get;
            set;
        }
        [DisplayName("Code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        public virtual InfCodeOccupation InfCodeOccupation
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_OCCUPATION__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Date FG")]
        [ColumnName("INF_OCCUPATION__DATE_FG")]
        public Nullable<DateTime> DateFg
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_OCCUPATION__DATE_MS")]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_OCCUPATION__ABS_DEB")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_OCCUPATION__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_OCCUPATION__ID")]
        [PrimaryKey("INF_OCCUPATION_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_OCCUPATION","JOIN_o750")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupant")]
        [ColumnName("INF_CD_OCCUPANT__ID")]
        [ForeignKey("INF_CD_OCCUPANT__INF_OCCUPATION","JOIN_o771")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public Int64 InfCodeOccupantId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code occupation")]
        [ColumnName("INF_CD_OCCUPATION__ID")]
        [ForeignKey("INF_CD_OCCUPATION__INF_OCCUPATION","JOIN_o774")]
        [UniqueKey("INF_OCCUPATION_UK_REF")]
        public Int64 InfCodeOccupationId
        {
            get;
            set;
        }
        [DisplayName("Traversé")]
        [ColumnName("INF_OCCUPATION__TRAVERSE")]
        public Nullable<Boolean> Traverse
        {
            get;
            set;
        }


    }
}
