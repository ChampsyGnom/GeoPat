using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class StyleViewModel
    {
        public List<DotSpatial.Symbology.PointShape> PointShapes { get; private set; }
        public StyleRuleViewModel BasicRule { get; private set; }
        private Boolean _isAnalyse;

        public Boolean IsAnalyse
        {
            get { return _isAnalyse; }
            set { _isAnalyse = value; }
        }

        public Boolean IsNotAnalyse
        {
            get { return !_isAnalyse; }
            set { _isAnalyse = !value; }
        }
        public String DisplayName { get; set; }

        public ObservableCollection<StyleRuleViewModel> Rules { get; private set; }

        public StyleViewModel()
        {
            this.Rules = new ObservableCollection<StyleRuleViewModel>();
            this.BasicRule = new StyleRuleViewModel();
            this.PointShapes = new List<DotSpatial.Symbology.PointShape>();
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Diamond);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Ellipse);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Hexagon);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Pentagon);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Rectangle);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Star);
            this.PointShapes.Add(DotSpatial.Symbology.PointShape.Triangle);
        }
    }
}
