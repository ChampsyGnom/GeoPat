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
	[DisplayName("Prestataire")]
    [TableName("INF_PRESTATAIRE")]
    [SchemaName("INF")]
    public class InfPrestataire 
    {
    	
        [DisplayName("Aire prestataires")]
        public virtual ObservableCollection<InfAirePrestataire> InfAirePrestataires
        {
            get;
            set;
        }
        [DisplayName("Type Prestataire")]
        [ColumnName("INF_CD_PRESTATAIRE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_CD_PRESTATAIRE__CD_PRESTATAIRE",null)]
        [UniqueKey("INF_PRESTATAIRE_UK_REF")]
        public virtual InfCodePrestataire InfCodePrestataire
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_PRESTATAIRE__CODE")]
        [UniqueKey("INF_PRESTATAIRE_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_PRESTATAIRE__ID")]
        [PrimaryKey("INF_PRESTATAIRE_PK")]
        [ForeignKeyAttribute("INF_PRESTATAIRE__INF_AIRE_PRESTATAIRE","JOIN_o984")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("INF_CD_PRESTATAIRE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfCodePrestataireId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_PRESTATAIRE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfPrestataire ()
		{
            this.InfAirePrestataires = new ObservableCollection<InfAirePrestataire>();
		}

    }
}
