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
	[DisplayName("Privilège des profils")]
    [TableName("PRF_PROFIL_RIGHT")]
    [SchemaName("PRF")]
    public class PrfProfilRight 
    {
    	
        [DisplayName("Privilèges")]
        [ColumnName("PRF_RIGHT__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_RIGHT__PRF_PROFIL_RIGHT",null)]
        public virtual PrfRight PrfRight
        {
            get;
            set;
        }
        [DisplayName("Profils")]
        [ColumnName("PRF_PROFIL__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_PROFIL__PRF_PROFIL_RIGHT",null)]
        public virtual PrfProfil PrfProfil
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_PROFIL_RIGHT__ID")]
        [PrimaryKey("PRF_PROFIL_RIGHT_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant2")]
        [ColumnName("PRF_RIGHT__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfRightId
        {
            get;
            set;
        }
        [DisplayName("Identifiant3")]
        [ColumnName("PRF_PROFIL__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfProfilId
        {
            get;
            set;
        }


		public PrfProfilRight ()
		{

		}

    }
}
