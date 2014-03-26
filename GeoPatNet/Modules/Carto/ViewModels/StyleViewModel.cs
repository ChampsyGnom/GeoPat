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
        }
    }
}
