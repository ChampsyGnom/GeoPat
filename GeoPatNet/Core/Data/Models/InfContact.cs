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
	[DisplayName("Contacts")]
    [TableName("INF_CONTACT")]
    [SchemaName("INF")]
    public class InfContact 
    {
    	
        [DisplayName("Contact des classeurss")]
        public virtual ObservableCollection<InfContactCls> InfContactClss
        {
            get;
            set;
        }
        [DisplayName("Adresse")]
        [ColumnName("INF_CONTACT__ADRESSE")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Adresse
        {
            get;
            set;
        }
        [DisplayName("Code postal")]
        [ColumnName("INF_CONTACT__CODE_POSTAL")]
        [MaxCharLength(10)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String CodePostal
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_CONTACT__ID")]
        [PrimaryKey("INF_CONTACT_PK")]
        [ForeignKeyAttribute("INF_CONTACT__INF_CONTACT_CLS","JOIN_o984")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Mail")]
        [ColumnName("INF_CONTACT__MAIL")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Mail
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("INF_CONTACT__NOM")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Prénom")]
        [ColumnName("INF_CONTACT__PRENOM")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Prenom
        {
            get;
            set;
        }
        [DisplayName("Téléphone fixe")]
        [ColumnName("INF_CONTACT__TEL_FIXE")]
        [MaxCharLength(30)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String TelFixe
        {
            get;
            set;
        }
        [DisplayName("Téléphone mobile")]
        [ColumnName("INF_CONTACT__TEL_MOBILE")]
        [MaxCharLength(30)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String TelMobile
        {
            get;
            set;
        }
        [DisplayName("Ville")]
        [ColumnName("INF_CONTACT__VILLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Ville
        {
            get;
            set;
        }


		public InfContact ()
		{
            this.InfContactClss = new ObservableCollection<InfContactCls>();
		}

    }
}
