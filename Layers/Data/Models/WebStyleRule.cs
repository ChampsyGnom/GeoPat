using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emash.GeoPat.Data.Models
{
    [Table("STYLE_RULE_WEB",Schema="WEB")]
    public partial class WebStyleRule
    {
        [Key]
        [Description("Identifiant de la règle")]
        [Column("ID",Order=0)]
        [Required()]
        public Int64 Id { get; set; }
        
        [Description("Identifiant du style")]
        [Column("STYLE_WEB__ID",Order=1)]
        [Required()]
        public Int64 StyleWebId { get; set; }
        
        [Description("Libellé de la règle")]
        [Column("LIBELLE",Order=2)]
        [Required()]
        [MaxLength(255)] 
        public String Libelle { get; set; }
        
        [Description("Increment des classe de valeurs")]
        [Column("INCREMENT_RANGE",Order=3)]
        public Nullable<Double> IncrementRange { get; set; }
        
        [Description("La règle de style est active")]
        [Column("IS_ACTIVE",Order=4)]
        [Required()]
        public Boolean IsActive { get; set; }
        
        [Description("Borne maximale des classe de valeurs")]
        [Column("MAX_RANGE",Order=5)]
        public Nullable<Double> MaxRange { get; set; }
        
        [Description("Borne minimal des classe de valeurs")]
        [Column("MIN_RANGE",Order=6)]
        public Nullable<Double> MinRange { get; set; }
        
        [Description("Valeur maximal de la classe de valeur")]
        [Column("MAX_VALUE",Order=7)]
        public Nullable<Double> MaxValue { get; set; }
        
        [Description("Valeur minimal de la classe de valeur")]
        [Column("MIN_VALUE",Order=8)]
        public Nullable<Double> MinValue { get; set; }
        
        [Description("Valeur unique de la règle")]
        [Column("UNIQUE_VALUE",Order=9)]
        [MaxLength(255)] 
        public String UniqueValue { get; set; }
        
        [Description("Taille des points")]
        [Column("POINT_SIZE",Order=10)]
        [Required()]
        public Int64 PointSize { get; set; }
        
        [Description("Couleur du contour des points")]
        [Column("POINT_STROKE_COLOR",Order=11)]
        [Required()]
        [MaxLength(10)] 
        public String PointStrokeColor { get; set; }
        
        [Description("Opacité du contour des points")]
        [Column("POINT_STROKE_OPACITY",Order=12)]
        [Required()]
        public Int64 PointStrokeOpacity { get; set; }
        
        [Description("Style du contour des points")]
        [Column("POINT_STROKE_STYLE",Order=13)]
        [Required()]
        [MaxLength(50)] 
        public String PointStrokeStyle { get; set; }
        
        [Description("Taille du contour des points")]
        [Column("POINT_STROKE_SIZE",Order=14)]
        [Required()]
        public Int64 PointStrokeSize { get; set; }
        
        [Description("Couleur de remplissage des points")]
        [Column("POINT_FILL_COLOR",Order=15)]
        [Required()]
        [MaxLength(10)] 
        public String PointFillColor { get; set; }
        
        [Description("Opacité du remplissage des points")]
        [Column("POINT_FILL_OPACITY",Order=16)]
        [Required()]
        public Int64 PointFillOpacity { get; set; }
        
        [Description("Symbole des points")]
        [Column("POINT_SYMBOL",Order=17)]
        [Required()]
        [MaxLength(50)] 
        public String PointSymbol { get; set; }
        
        [Description("Image des points")]
        [Column("POINT_IMAGE",Order=18)]
        [Required()]
        [MaxLength(255)] 
        public String PointImage { get; set; }
        
        [Description("Taille des lignes")]
        [Column("LINE_SIZE",Order=19)]
        [Required()]
        public Int64 LineSize { get; set; }
        
        [Description("Couleur des lignes")]
        [Column("LINE_STROKE_COLOR",Order=20)]
        [Required()]
        [MaxLength(10)] 
        public String LineStrokeColor { get; set; }
        
        [Description("Opacité des lignes")]
        [Column("LINE_STROKE_OPACITY",Order=21)]
        [Required()]
        public Int64 LineStrokeOpacity { get; set; }
        
        [Description("Style des lignes")]
        [Column("LINE_STROKE_STYLE",Order=22)]
        [Required()]
        [MaxLength(50)] 
        public String LineStrokeStyle { get; set; }
        
        [Description("Couleur des contours des polygones")]
        [Column("POLY_STROKE_COLOR",Order=23)]
        [Required()]
        [MaxLength(10)] 
        public String PolyStrokeColor { get; set; }
        
        [Description("Opacité des contours des polygones")]
        [Column("POLY_STROKE_OPACITY",Order=24)]
        [Required()]
        public Int64 PolyStrokeOpacity { get; set; }
        
        [Description("Style du contours des polygones")]
        [Column("POLY_STROKE_STYLE",Order=25)]
        [Required()]
        [MaxLength(50)] 
        public String PolyStrokeStyle { get; set; }
        
        [Description("Taille du contour des polygones")]
        [Column("POLY_STROKE_SIZE",Order=26)]
        [Required()]
        public Int64 PolyStrokeSize { get; set; }
        
        [Description("Couleur de remplissage des polygones")]
        [Column("POLY_FILL_COLOR",Order=27)]
        [Required()]
        [MaxLength(10)] 
        public String PolyFillColor { get; set; }
        
        [Description("Opacité du remplissage des polygones")]
        [Column("POLY_FILL_OPACITY",Order=28)]
        [Required()]
        public Int64 PolyFillOpacity { get; set; }
        
    }
}
