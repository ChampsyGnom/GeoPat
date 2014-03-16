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
	[DisplayName("Tables")]
    [TableName("PRF_TABLE")]
    [SchemaName("PRF")]
    public class PrfTable 
    {
    	
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
        [ForeignKey("PRF_SCHEMA__PRF_TABLE",null)]
        public virtual PrfSchema PrfSchema
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("PRF_TABLE__ID")]
        [PrimaryKey("PRF_TABLE_PK")]
        [ForeignKeyAttribute("PRF_TABLE__PRF_PROFIL_TABLE","JOIN_o148")]
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
        [ColumnName("PRF_TABLE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Nom")]
        [ColumnName("PRF_TABLE__NAME")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Name
        {
            get;
            set;
        }


    }
}
