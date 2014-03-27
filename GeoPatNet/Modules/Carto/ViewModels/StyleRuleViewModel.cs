using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DotSpatial.Symbology;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{

    public class StyleRuleViewModel : IStyleRuleSymbolizer
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        private Color _color;


        public Color Color
        {
            get { return _color; }
            set { _color = value; this.RaisePropertyChanged("Color"); }
        }
        private double _pointSize;


        public double PointSize
        {
            get { return _pointSize; }
            set { _pointSize = value; this.RaisePropertyChanged("PointSize"); }
        }
        private double _pointBorderSize;


        public double PointBorderSize
        {
            get { return _pointBorderSize; }
            set { _pointBorderSize = value; this.RaisePropertyChanged("PointBorderSize"); }
        }
        private Color _pointBorderColor;


        public Color PointBorderColor
        {
            get { return _pointBorderColor; }
            set { _pointBorderColor = value; this.RaisePropertyChanged("PointBorderColor"); }
        }
        private DotSpatial.Symbology.PointShape _pointShape;


        public DotSpatial.Symbology.PointShape PointShape
        {
            get { return _pointShape; }
            set { _pointShape = value; this.RaisePropertyChanged("PointShape"); }
        }
        private double _lineSize;


        public double LineSize
        {
            get { return _lineSize; }
            set { _lineSize = value; this.RaisePropertyChanged("LineSize"); }
        }
        private double _lineBorderSize;


        public double LineBorderSize
        {
            get { return _lineBorderSize; }
            set { _lineBorderSize = value; this.RaisePropertyChanged("LineBorderSize"); }
        }
        private Color _lineBorderColor;


        public Color LineBorderColor
        {
            get { return _lineBorderColor; }
            set { _lineBorderColor = value; this.RaisePropertyChanged("LineBorderColor"); }
        }
        private double _polygonBorderSize;


        public double PolygonBorderSize
        {
            get { return _polygonBorderSize; }
            set { _polygonBorderSize = value; this.RaisePropertyChanged("PolygonBorderSize"); }
        }
        private Color _polygonBorderColor;


        public Color PolygonBorderColor
        {
            get { return _polygonBorderColor; }
            set { _polygonBorderColor = value; this.RaisePropertyChanged("PolygonBorderColor"); }
        }

        public StyleRuleViewModel()
        {
            this.Color = Colors.Green;
            this.PointSize = 16;
            this.PointBorderSize   = 2;
            this.PointBorderColor = Colors.DarkGray;
            this.PointShape = DotSpatial.Symbology.PointShape.Ellipse;
            this.LineSize = 6;
            this.LineBorderSize = 2;
            this.LineBorderColor = Colors.DarkGray;
            this.PolygonBorderSize = 2;
            this.PolygonBorderColor = Colors.DarkGray;
        }



        public DotSpatial.Symbology.IPointSymbolizer ToPointSymbolizer()
        {
            SimpleSymbol s = new SimpleSymbol(this.Color.ToDrawingColor(), this.PointShape, this.PointSize);
            s.OutlineColor = this.PointBorderColor.ToDrawingColor();
            s.OutlineWidth = this.PointBorderSize;
            s.PointShape = this.PointShape;
            s.OutlineOpacity = 1f;
            s.UseOutline = true;
            DotSpatial.Symbology.PointSymbolizer symbolizer = new DotSpatial.Symbology.PointSymbolizer(s);     
            return symbolizer;
        }


        public ILineSymbolizer ToLineSymbolizer()
        {          
            SimpleStroke stBase = new SimpleStroke(this.LineSize,this.Color.ToDrawingColor());
            SimpleStroke stBorder = new SimpleStroke(this.LineSize+this.LineBorderSize , this._lineBorderColor .ToDrawingColor());
            LineSymbolizer line = new LineSymbolizer(new SimpleStroke[] { stBorder,stBase });
            return line;
        }



        public IPolygonSymbolizer ToPolygonSymbolizer()
        {
            PolygonSymbolizer ps = new PolygonSymbolizer();
            ps.SetFillColor(this.Color.ToDrawingColor());
            ps.SetOutline(this.PolygonBorderColor.ToDrawingColor(), this.PolygonBorderSize);
            return ps;
        }
    }
}
