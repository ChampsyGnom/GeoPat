using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class CustomDisplayableEntityViewModel<M>
    {
        public ObservableCollection<CustomDisplayablePropertyViewModel<M>> Fields { get; set; }
        public String DisplayName { get; set; }
        public CustomDisplayableEntityViewModel()
        {
            this.Fields = new ObservableCollection<CustomDisplayablePropertyViewModel<M>>();
        }
    }
}
