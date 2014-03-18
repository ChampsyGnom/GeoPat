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
	[DisplayName("Utilisateurs")]
    [TableName("PRF_USER")]
    [SchemaName("PRF")]
    public class PrfUser 
    {
    	
        [DisplayName("Profil des utilisateurss")]
        public virtual ICollection<PrfUserProfil> PrfUserProfils
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_USER__ID")]
        [PrimaryKey("PRF_USER_PK")]
        [ForeignKeyAttribute("PRF_USER__PRF_USER_PROFIL","JOIN_o157")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Login")]
        [ColumnName("PRF_USER__LOGIN")]
        [UniqueKey("PRF_USER_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Login
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("PRF_USER__NOM")]
        [UniqueKey("PRF_USER_UK_2")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Nom
        {
            get;
            set;
        }
        [DisplayName("Passsword")]
        [ColumnName("PRF_USER__PASSSWORD")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Passsword
        {
            get;
            set;
        }
        [DisplayName("Prénom")]
        [ColumnName("PRF_USER__PRENOM")]
        [UniqueKey("PRF_USER_UK_2")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Prenom
        {
            get;
            set;
        }


    }
}
