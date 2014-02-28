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
	[DisplayName("Aires")]
    [TableName("INF_AIRE")]
    [SchemaName("INF")]
    public class InfAire : IInfAire
    {
    	
        [DisplayName("Parking aires")]
        public virtual ICollection<InfCodeParkingInfAire> InfCodeParkingInfAires
        {
            get;
            set;
        }
        [DisplayName("Prestataire Aires")]
        public virtual ICollection<InfPrestataireInfAire> InfPrestataireInfAires
        {
            get;
            set;
        }
        [DisplayName("Service aires")]
        public virtual ICollection<InfCodeServiceInfAire> InfCodeServiceInfAires
        {
            get;
            set;
        }
        [DisplayName("Chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CHAUSSEE__INF_AIRE",null)]
        [UniqueKey("INF_AIRE_UK_REF")]
        public virtual InfChaussee InfChaussee
        {
            get;
            set;
        }
        [DisplayName("Type Aires")]
        [ColumnName("INF_CD_AIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_AIRE__INF_AIRE",null)]
        public virtual InfCodeAire InfCodeAire
        {
            get;
            set;
        }
        [DisplayName("Bilatérale")]
        [ColumnName("INF_AIRE__BILATERALE")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> Bilaterale
        {
            get;
            set;
        }
        [DisplayName("Commentaires")]
        [ColumnName("INF_AIRE__OBSERV")]
        [MaxCharLength(250)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Observ
        {
            get;
            set;
        }
        [DisplayName("Date MS")]
        [ColumnName("INF_AIRE__DATE_MS")]
        [ControlType(ControlType.Date)]
        [AllowNull(true)]
        public Nullable<DateTime> DateMs
        {
            get;
            set;
        }
        [DisplayName("Début")]
        [ColumnName("INF_AIRE__ABS_DEB")]
        [UniqueKey("INF_AIRE_UK_REF")]
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
        [DisplayName("Demi tour")]
        [ColumnName("INF_AIRE__DEMI_TOUR")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> DemiTour
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_AIRE__ID")]
        [PrimaryKey("INF_AIRE_PK")]
        [ForeignKeyAttribute("INF_CD_PARKING__INF_AIRE","JOIN_o961")]
        [ForeignKeyAttribute("INF_PRESTATAIRE__INF_AIRE2","JOIN_o959")]
        [ForeignKeyAttribute("INF_CD_SERVICE__INF_AIRE","JOIN_o962")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant aire")]
        [ColumnName("INF_CD_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeAireId
        {
            get;
            set;
        }
        [DisplayName("Identifiant chaussée")]
        [ColumnName("INF_CHAUSSEE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfChausseeId
        {
            get;
            set;
        }
        [DisplayName("N° Exploitation")]
        [ColumnName("INF_AIRE__NUM_EXPLOIT")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String NumExploit
        {
            get;
            set;
        }
        [DisplayName("Nom d'usage")]
        [ColumnName("INF_AIRE__NOM")]
        [MaxCharLength(60)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Passerelle")]
        [ColumnName("INF_AIRE__PASSERELLE")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> Passerelle
        {
            get;
            set;
        }


    }
}
