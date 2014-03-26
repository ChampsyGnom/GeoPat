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
	[DisplayName("Styles")]
    [TableName("INF_STYLE")]
    [SchemaName("INF")]
    public class InfStyle 
    {
    	
        [DisplayName("Régle de styles")]
        public virtual ObservableCollection<InfStyleRule> InfStyleRules
        {
            get;
            set;
        }
        [DisplayName("Défault carto")]
        [ColumnName("INF_STYLE__DEFAUT_CARTO")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean DefautCarto
        {
            get;
            set;
        }
        [DisplayName("Défault statistique")]
        [ColumnName("INF_STYLE__DEFAUT_STAT")]
        [ControlType(ControlType.Check)]
        [AllowNull(false)]
        public Boolean DefautStat
        {
            get;
            set;
        }
        [DisplayName("Entité")]
        [ColumnName("INF_STYLE__ENTITY_NAME")]
        [MaxCharLength(100)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String EntityName
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_STYLE__ID")]
        [PrimaryKey("INF_STYLE__PK")]
        [ForeignKeyAttribute("INF_STYLE__INF_STYLE_RULE","JOIN_o1021")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_STYLE__LIBELLE")]
        [MaxCharLength(2000)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }


		public InfStyle ()
		{
            this.InfStyleRules = new ObservableCollection<InfStyleRule>();
		}

    }
}
