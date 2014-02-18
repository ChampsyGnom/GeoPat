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
	[DisplayName("Bretelle")]
    [TableName("INF_BRETELLE")]
    [SchemaName("INF")]
    public class InfBretelle : IInfBretelle
    {
    	
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_BRETELLE__ABS_DEB")]
        [UniqueKey("INF_BRETELLE_UK_REF")]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Extrémité")]
        [ColumnName("INF_BRETELLE__EXTREMITE")]
        public String Extremite
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_BRETELLE__ID")]
        [PrimaryKey("INF_BRETELLE_PK")]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_BRETELLE","JOIN_o746")]
        [UniqueKey("INF_BRETELLE_UK_REF")]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_BRETELLE__LIBELLE")]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("N° bretelle")]
        [ColumnName("INF_BRETELLE__NUM")]
        public String Num
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        [ColumnName("INF_BRETELLE__NUM_EXPLOIT")]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom bretelle")]
        [ColumnName("INF_BRETELLE__NOM")]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Type")]
        [ColumnName("INF_BRETELLE__TYPE")]
        public String Type
        {
            get;
            set;
        }


    }
}
