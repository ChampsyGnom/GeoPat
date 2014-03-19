using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Modules.Document.ViewModels
{
    public class DocumentCodeViewModel
    {
        public String Code { get; set; }
        public String Libelle { get; set; }
        public String Path { get; set; }
        public Int64  Id { get; set; }
        public ObservableCollection<DocumentViewModel> Documents { get; private set; }

        public DocumentCodeViewModel()
        {
            this.Documents = new ObservableCollection<DocumentViewModel>();
        }
    }
}
