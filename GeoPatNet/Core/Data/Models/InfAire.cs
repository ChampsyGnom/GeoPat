using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Aires")]
    [TableName("INF_AIRE")]
    [SchemaName("INF")]
    public class InfAire 
    {
    	
        [DisplayName("Aire parkings")]
        public virtual ObservableCollection<InfAireParking> InfAireParkings
        {
            get;
            set;
        }
        [DisplayName("Aire prestataires")]
        public virtual ObservableCollection<InfAirePrestataire> InfAirePrestataires
        {
            get;
            set;
        }
        [DisplayName("Aire services")]
        public virtual ObservableCollection<InfAireService> InfAireServices
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
        [UniqueKey("INF_AIRE_UK_REF")]
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
        [LocationAttribute(LocationAttributeType.ReferenceDeb)]
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
        [ForeignKeyAttribute("INF_AIRE__INF_AIRE_PARKING","JOIN_o911")]
        [ForeignKeyAttribute("INF_AIRE__INF_AIRE_PRESTATAIRE","JOIN_o913")]
        [ForeignKeyAttribute("INF_AIRE__INF_AIRE_SERVICE","JOIN_o909")]
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
        [DisplayName("Identifiant type aire")]
        [ColumnName("INF_CD_AIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodeAireId
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


		public InfAire ()
		{
            this.InfAireParkings = new ObservableCollection<InfAireParking>();
            this.InfAirePrestataires = new ObservableCollection<InfAirePrestataire>();
            this.InfAireServices = new ObservableCollection<InfAireService>();
		}

    }
}
