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
	[DisplayName("Sécurité")]
    [TableName("INF_SECURITE")]
    [SchemaName("INF")]
    public class InfSecurite : IInfSecurite
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        public virtual InfCodePosit InfCodePosit
        {
            get;
            set;
        }
        [DisplayName("Code sécurité")]
        [ColumnName("INF_CD_SECURITE__ID")]
        public virtual InfCodeSecurite InfCodeSecurite
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_SECURITE__ABS_DEB")]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Fin")]
        [ColumnName("INF_SECURITE__ABS_FIN")]
        public Nullable<Int64> AbsFin
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_SECURITE__ID")]
        [PrimaryKey("INF_SECURITE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_SECURITE","JOIN_o757")]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code position")]
        [ColumnName("INF_CD_POSIT__ID")]
        [ForeignKey("INF_CD_POSIT__INF_SECURITE","JOIN_o775")]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public Int64 InfCodePositId
        {
            get;
            set;
        }
        [DisplayName("Identifiant code sécurité")]
        [ColumnName("INF_CD_SECURITE__ID")]
        [ForeignKey("INF_CD_SECURITE__INF_SECURITE","JOIN_o776")]
        [UniqueKey("INF_SECURITE_UK_REF")]
        public Int64 InfCodeSecuriteId
        {
            get;
            set;
        }


    }
}
