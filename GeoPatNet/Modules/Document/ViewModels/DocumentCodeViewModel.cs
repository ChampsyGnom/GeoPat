using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
namespace Emash.GeoPatNet.Modules.Document.ViewModels
{
    public class DocumentCodeViewModel : INotifyPropertyChanged
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
        public String SchemaDocumentPath { get; private set; }
        public String Code { get; set; }
        public String Libelle { get; set; }
        public String Path { get; set; }
        public Int64  Id { get; set; }
        public ObservableCollection<DocumentViewModel> Documents { get; private set; }
        
        public DocumentCodeViewModel(String schemaDocumentPath)
        {
            this.SchemaDocumentPath = schemaDocumentPath;
            this.Documents = new ObservableCollection<DocumentViewModel>();
        }

        public string AbsolutePath
        { 
            get
            {
                return System.IO.Path.Combine(this.SchemaDocumentPath, this.Path);
            }
        }

       
    }
}
