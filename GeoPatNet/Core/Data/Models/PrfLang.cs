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
	[DisplayName("Langue")]
    [TableName("PRF_LANG")]
    [SchemaName("PRF")]
    public class PrfLang 
    {
    	
        [DisplayName("Clé")]
        [ColumnName("PRF_LANG__KEY")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Key
        {
            get;
            set;
        }
        [DisplayName("Code ISO")]
        [ColumnName("PRF_LANG__CODE_ISO")]
        [MaxCharLength(3)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String CodeIso
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_LANG__ID")]
        [PrimaryKey("PRF_LANG_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Valeur")]
        [ColumnName("PRF_LANG__VALEUR")]
        [MaxCharLength(1000)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Valeur
        {
            get;
            set;
        }


		public PrfLang ()
		{

		}

    }
}
