
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public class TemplateNodeFolderViewModel : TemplateNodeViewModel
    {
       

        public ObservableCollection<TemplateNodeViewModel> Nodes { get; private set; }

        public TemplateNodeFolderViewModel()
        {
           
        }

        public TemplateNodeFolderViewModel(SigNode model)
        {
            this.Nodes = new ObservableCollection<TemplateNodeViewModel>();
            this.Model = model;
            this.DisplayName = model.Libelle;
        }
    }
}
