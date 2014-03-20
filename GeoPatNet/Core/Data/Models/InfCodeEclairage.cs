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
	[DisplayName("Code éclairage")]
    [TableName("INF_CD_ECLAIRAGE")]
    [SchemaName("INF")]
    public class InfCodeEclairage 
    {
    	
        [DisplayName("Eclairages")]
        public virtual ObservableCollection<InfEclairage> InfEclairages
        {
            get;
            set;
        }
        [DisplayName("Code")]
        [ColumnName("INF_CD_ECLAIRAGE__CODE")]
        [UniqueKey("INF_CD_ECLAIRAGE_UK_REF")]
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
        [ColumnName("INF_CD_ECLAIRAGE__ID")]
        [PrimaryKey("INF_CD_ECLAIRAGE_PK")]
        [ForeignKeyAttribute("INF_CD_ECLAIRAGE__INF_ECLAIRAGE","JOIN_o961")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_CD_ECLAIRAGE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String Libelle
        {
            get;
            set;
        }


		public InfCodeEclairage ()
		{
            this.InfEclairages = new ObservableCollection<InfEclairage>();
		}

    }
}
