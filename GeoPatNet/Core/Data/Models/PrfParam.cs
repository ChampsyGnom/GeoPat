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
	[DisplayName("Paramètres")]
    [TableName("PRF_PARAM")]
    [SchemaName("PRF")]
    public class PrfParam 
    {
    	
        [DisplayName("Schémas")]
        [ColumnName("PRF_SCHEMA__ID")]
        [AllowNull(true)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_SCHEMA__PRF_PARAM",null)]
        public virtual PrfSchema PrfSchema
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("PRF_PARAM__CODE")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_PARAM__ID")]
        [PrimaryKey("PRF_PARAM_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("PRF_SCHEMA__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(true)]
        public Nullable<Int64> PrfSchemaId
        {
            get;
            set;
        }
        [DisplayName("Valeur")]
        [ColumnName("PRF_PARAM__VALEUR")]
        [MaxCharLength(500)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Valeur
        {
            get;
            set;
        }


		public PrfParam ()
		{

		}

    }
}
