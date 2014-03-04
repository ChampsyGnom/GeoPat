using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;

namespace Emash.GeoPatNet.Infrastructure.Views
{
    /// <summary>
    /// Logique d'interaction pour SwapRegionView.xaml
    /// </summary>
    public partial class SwapRegionView : UserControl
    {
        private List<Object> _views;

        public List<Object> Views
        {
            get { return _views; }

        }
        private IRegionManager _regionManager;

        public IRegionManager RegionManager
        {
            get { return _regionManager; }

        }


        public SwapRegionView()
        {
            this._views = new List<object>();
            InitializeComponent();
        }



        public void SwapView()
        {
            IRegion region = this._regionManager.Regions["SwapableRegion"];
            if (region.Views.Count() == 0 && this._views.Count() > 0)
            {
                region.Add(this._views[0]);
                region.Activate(this._views[0]);
            }
            else
            {

                int viewIndex = -1;
                foreach (var view in region.Views)
                {
                    if (this._views.IndexOf(view) != -1)
                    { viewIndex = this._views.IndexOf(view); }
                }

                foreach (var view in region.Views.ToArray())
                { region.Remove(view); }
                if (viewIndex != -1)
                {
                    viewIndex++;
                    if (viewIndex > (_views.Count - 1))
                    { viewIndex = 0; }

                    region.Add(this._views[viewIndex]);
                    region.Activate(this._views[viewIndex]);
                }


            }
        }

        public void Configure(IRegionManager regionManager, Object[] views)
        {
            this._regionManager = regionManager;
            foreach (Object o in views)
            { this._views.Add(o); }

        }
    }
}
