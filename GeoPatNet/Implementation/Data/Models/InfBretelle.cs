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
	[DisplayName("Bretelle")]
    [TableName("INF_BRETELLE")]
    [SchemaName("INF")]
    public class InfBretelle : IInfBretelle
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
        [DisplayName("Début")]
        [ColumnName("INF_BRETELLE__ABS_DEB")]
        [UniqueKey("INF_BRETELLE_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 AbsDeb
        {
            get;
            set;
        }
        [DisplayName("Extrémité")]
        [ColumnName("INF_BRETELLE__EXTREMITE")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Extremite
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_BRETELLE__ID")]
        [PrimaryKey("INF_BRETELLE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [ForeignKey("INF_CHAUSSEE__INF_BRETELLE","JOIN_o769")]
        [UniqueKey("INF_BRETELLE_UK_REF")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Integer)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_BRETELLE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("N° bretelle")]
        [ColumnName("INF_BRETELLE__NUM")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Num
        {
            get;
            set;
        }
        [DisplayName("N° exploitation")]
        [ColumnName("INF_BRETELLE__NUM_EXPLOIT")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom bretelle")]
        [ColumnName("INF_BRETELLE__NOM")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Type")]
        [ColumnName("INF_BRETELLE__TYPE")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Type
        {
            get;
            set;
        }


    }
}
