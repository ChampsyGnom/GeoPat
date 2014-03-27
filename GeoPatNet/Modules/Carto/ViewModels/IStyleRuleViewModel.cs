using System;
using System.ComponentModel;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public interface IStyleRuleSymbolizer : INotifyPropertyChanged
    {
        System.Windows.Media.Color Color { get; set; }
        System.Windows.Media.Color LineBorderColor { get; set; }
        double LineBorderSize { get; set; }
        double LineSize { get; set; }
        System.Windows.Media.Color PointBorderColor { get; set; }
        double PointBorderSize { get; set; }
        DotSpatial.Symbology.PointShape PointShape { get; set; }
        double PointSize { get; set; }
        System.Windows.Media.Color PolygonBorderColor { get; set; }
        double PolygonBorderSize { get; set; }
        DotSpatial.Symbology.IPointSymbolizer ToPointSymbolizer();
        DotSpatial.Symbology.ILineSymbolizer ToLineSymbolizer();


        DotSpatial.Symbology.IPolygonSymbolizer ToPolygonSymbolizer();
    }
}
