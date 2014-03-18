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
	[DisplayName("Table des profil")]
    [TableName("PRF_PROFIL_TABLE")]
    [SchemaName("PRF")]
    public class PrfProfilTable 
    {
    	
        [DisplayName("Profils")]
        [ColumnName("PRF_PROFIL__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_PROFIL__PRF_PROFIL_TABLE",null)]
        public virtual PrfProfil PrfProfil
        {
            get;
            set;
        }
        [DisplayName("Tables")]
        [ColumnName("PRF_TABLE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_TABLE__PRF_PROFIL_TABLE",null)]
        public virtual PrfTable PrfTable
        {
            get;
            set;
        }
        [DisplayName("Autoriser écriture")]
        [ColumnName("PRF_PROFIL_TABLE__WRITE")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean Write
        {
            get;
            set;
        }
        [DisplayName("Autoriser import")]
        [ColumnName("PRF_PROFIL_TABLE__IMPORT")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean Import
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_PROFIL_TABLE__ID")]
        [PrimaryKey("PRF_PROFIL_TABLE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("PRF_PROFIL__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfProfilId
        {
            get;
            set;
        }
        [DisplayName("Identifiant3")]
        [ColumnName("PRF_TABLE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfTableId
        {
            get;
            set;
        }


		public PrfProfilTable ()
		{

		}

    }
}
