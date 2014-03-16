using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Attributes;
using System.Data.Entity.Spatial;
using Emash.GeoPatNet.Infrastructure.Enums;
namespace Emash.GeoPatNet.Data.Models
{
	[DisplayName("Profil des utilisateurs")]
    [TableName("PRF_USER_PROFIL")]
    [SchemaName("PRF")]
    public class PrfUserProfil 
    {
    	
        [DisplayName("Profils")]
        [ColumnName("PRF_PROFIL__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_PROFIL__PRF_USER_PROFIL",null)]
        public virtual PrfProfil PrfProfil
        {
            get;
            set;
        }
        [DisplayName("Utilisateurs")]
        [ColumnName("PRF_USER__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("PRF_USER__PRF_USER_PROFIL",null)]
        public virtual PrfUser PrfUser
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_USER_PROFIL__ID")]
        [PrimaryKey("PRF_USER_PROFIL_PK")]
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
        [ColumnName("PRF_USER__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfUserId
        {
            get;
            set;
        }


    }
}
