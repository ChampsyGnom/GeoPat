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
	[DisplayName("Régle de style")]
    [TableName("INF_STYLE_RULE")]
    [SchemaName("INF")]
    public class InfStyleRule 
    {
    	
        [DisplayName("Styles")]
        [ColumnName("INF_STYLE__ID")]
        [AllowNull(false)]
        [ControlType(ControlType.Combo)]
        [ForeignKey("INF_STYLE__INF_STYLE_RULE",null)]
        public virtual InfStyle InfStyle
        {
            get;
            set;
        }
        [DisplayName("Couleur de la bordure des lignes")]
        [ColumnName("INF_STYLE_RULE__LINE_BORDER_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String LineBorderColor
        {
            get;
            set;
        }
        [DisplayName("Couleur de la bordure des points")]
        [ColumnName("INF_STYLE_RULE__POINT_BORDER_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String PointBorderColor
        {
            get;
            set;
        }
        [DisplayName("Couleur de la bordure des polygones")]
        [ColumnName("INF_STYLE_RULE__POLY_BORDER_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String PolyBorderColor
        {
            get;
            set;
        }
        [DisplayName("Couleur des points")]
        [ColumnName("INF_STYLE_RULE__POINT_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String PointColor
        {
            get;
            set;
        }
        [DisplayName("Couleur des polygones")]
        [ColumnName("INF_STYLE_RULE__POLY_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String PolyColor
        {
            get;
            set;
        }
        [DisplayName("Couleurs des lignes")]
        [ColumnName("INF_STYLE_RULE__LINE_COLOR")]
        [MaxCharLength(15)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String LineColor
        {
            get;
            set;
        }
        [DisplayName("Forme des points")]
        [ColumnName("INF_STYLE_RULE__POINT_SHAPE")]
        [MaxCharLength(50)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String PointShape
        {
            get;
            set;
        }
        [Browsable(false)]
        [DisplayName("Identifiant")]
        [ColumnName("INF_STYLE_RULE__ID")]
        [PrimaryKey("INF_STYLE_RULE_PK")]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 Id
        {
            get;
            set;
        }
        [DisplayName("Identifiant style")]
        [ColumnName("INF_STYLE__ID")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.None)]
        [AllowNull(false)]
        public Int64 InfStyleId
        {
            get;
            set;
        }
        [DisplayName("Libellé")]
        [ColumnName("INF_STYLE_RULE__LIBELLE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(false)]
        public String Libelle
        {
            get;
            set;
        }
        [DisplayName("Régle pour les valeur null")]
        [ColumnName("INF_STYLE_RULE__IS_FOR_NULL")]
        [ControlType(ControlType.Check)]
        [AllowNull(true)]
        public Nullable<Boolean> IsForNull
        {
            get;
            set;
        }
        [DisplayName("Taille de la bordure des lignes")]
        [ColumnName("INF_STYLE_RULE__LINE_BORDER_SIZE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> LineBorderSize
        {
            get;
            set;
        }
        [DisplayName("Taille de la bordure des poins")]
        [ColumnName("INF_STYLE_RULE__POINT_BORDER_SIZE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> PointBorderSize
        {
            get;
            set;
        }
        [DisplayName("Taille de la bordure des polygones")]
        [ColumnName("INF_STYLE_RULE__POLY_BORDER_SIZE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> PolyBorderSize
        {
            get;
            set;
        }
        [DisplayName("Taille des lignes")]
        [ColumnName("INF_STYLE_RULE__LINE_SIZE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> LineSize
        {
            get;
            set;
        }
        [DisplayName("Taille des points")]
        [ColumnName("INF_STYLE_RULE__POINT_SIZE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> PointSize
        {
            get;
            set;
        }
        [DisplayName("Valeur maxi numérique")]
        [ColumnName("INF_STYLE_RULE__NUM_MAX_VALUE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> NumMaxValue
        {
            get;
            set;
        }
        [DisplayName("Valeur mini numérique")]
        [ColumnName("INF_STYLE_RULE__NUM_MIN_VALUE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> NumMinValue
        {
            get;
            set;
        }
        [DisplayName("Valeur unique numérique")]
        [ColumnName("INF_STYLE_RULE__NUM_UNQ_VALUE")]
        [RangeValue(-999999999999,999999999999)]
        [ControlType(ControlType.Decimal)]
        [AllowNull(true)]
        public Nullable<Double> NumUnqValue
        {
            get;
            set;
        }
        [DisplayName("Valeur unique texte")]
        [ColumnName("INF_STYLE_RULE__TXT_UNQ_VALUE")]
        [MaxCharLength(200)]
        [ControlType(ControlType.Text)]
        [AllowNull(true)]
        public String TxtUnqValue
        {
            get;
            set;
        }


		public InfStyleRule ()
		{

		}

    }
}
