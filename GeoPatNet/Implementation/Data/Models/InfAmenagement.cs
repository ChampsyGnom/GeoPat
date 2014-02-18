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
	[DisplayName("Aménagement")]
    [TableName("INF_AMENAGEMENT")]
    [SchemaName("INF")]
    public class InfAmenagement : IInfAmenagement
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code aménagement")]
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        public virtual InfCodeAmenagement InfCodeAmenagement
        {
            get;
            set;
        }
        [DisplayName("Commentaire")]
        [ColumnName("INF_AMENAGEMENT__INFO")]
        public String Info
        {
            get;
            set;
        }
        [DisplayName("Coût")]
        [ColumnName("INF_AMENAGEMENT__COUT")]
        public Nullable<Int64> Cout
        {
            get;
            set;
        }
        [DisplayName("Date début")]
        [ColumnName("INF_AMENAGEMENT__DATE_DEB")]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public DateTime DateDeb
        {
            get;
            set;
        }
        [DisplayName("Date fin")]
        [ColumnName("INF_AMENAGEMENT__DATE_FIN")]
        public Nullable<DateTime> DateFin
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_AMENAGEMENT__ABS_DEB")]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_AMENAGEMENT__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AMENAGEMENT__ID")]
        [PrimaryKey("INF_AMENAGEMENT_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_AMENAGEMENT","JOIN_o743")]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code aménagement")]
        [ColumnName("INF_CD_AMENAGEMENT__ID")]
        [ForeignKey("INF_CD_AMENAGEMENT__INF_AMENAGEMENT","JOIN_o764")]
        [UniqueKey("INF_AMENAGEMENT_UK_REF")]
        public Int64 InfCodeAmenagementId
        {
            get;
            set;
        }


    }
}
