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
	[DisplayName("Profils")]
    [TableName("PRF_PROFIL")]
    [SchemaName("PRF")]
    public class PrfProfil 
    {
    	
        [DisplayName("Privilège des profilss")]
        public virtual ICollection<PrfProfilRight> PrfProfilRights
        {
            get;
            set;
        }
        [DisplayName("Profil des utilisateurss")]
        public virtual ICollection<PrfUserProfil> PrfUserProfils
        {
            get;
            set;
        }
        [DisplayName("Table des profils")]
        public virtual ICollection<PrfProfilTable> PrfProfilTables
        {
            get;
            set;
        }
        [DisplayName("Schémas")]
        [ColumnName("PRF_SCHEMA__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("ASSOCIATION_2",null)]
        public virtual PrfSchema PrfSchema
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("PRF_PROFIL__CODE")]
        [UniqueKey("PRF_PROFIL_UK_REF")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Code
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant profil")]
        [ColumnName("PRF_PROFIL__ID")]
        [PrimaryKey("PRF_PROFIL_PK")]
        [ForeignKeyAttribute("PRF_PROFIL__PRF_PROFIL_RIGHT","JOIN_o151")]
        [ForeignKeyAttribute("PRF_PROFIL__PRF_USER_PROFIL","JOIN_o150")]
        [ForeignKeyAttribute("PRF_PROFIL__PRF_PROFIL_TABLE","JOIN_o149")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant schéma")]
        [ColumnName("PRF_SCHEMA__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 PrfSchemaId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("PRF_PROFIL__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


    }
}
