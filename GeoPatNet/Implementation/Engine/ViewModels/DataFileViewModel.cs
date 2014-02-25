using Emash.GeoPatNet.Data.Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Emash.GeoPatNet.Engine.Implentation.ViewModels
{
    public class DataFileViewModel : INotifyPropertyChanged
    {
        public Dispatcher _dispatcher;
        public List<String> _headers;
        public List<List<String>> _datas;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                this._dispatcher.Invoke(new Action(delegate() { handler(this, new PropertyChangedEventArgs(name)); }));
                
            }
        }

        public DataFileViewModel(string file, EntityTableInfo entityTableInfo, bool isLegacy)
        {
            // TODO: Complete member initialization
            this._dispatcher = System.Windows.Application.Current.Dispatcher;
            this.FilePath = file;
            this.TableInfo = entityTableInfo;
            this.IsLegacy = true;
            this.FileInfo = new FileInfo(this.FilePath);
            this._headers = new List<string>();
            this._datas = new List<List<string>>();
            

        }

        public void ReadFile()
        {
            FileStream stream = new FileStream(this.FilePath, FileMode.Open);
            StreamReader reader = null;
            if (this.IsLegacy)
            { reader = new StreamReader (stream , System .Text.Encoding .GetEncoding (1252));}
            else
            {reader = new StreamReader (stream,System.Text.Encoding.Unicode ); }

            String header = reader.ReadLine();
            this._headers = header.Split(";".ToCharArray(), StringSplitOptions.None).ToList ();

            String data = null;
            while ((data = reader.ReadLine()) != null)
            {this._datas.Add(data.Split(";".ToCharArray(), StringSplitOptions.None).ToList());}

            reader.Close();
            reader.Dispose();
            stream.Close();
            stream.Dispose();
            this.RaisePropertyChanged("RowCount");
        }

        public int RowCount
        {
            get {
                return this._datas.Count;
            }
        }
        public int Level
        {
            get { return this.TableInfo.Level; }
        }
        private FileInfo FileInfo { get; set; }
        public String FilePath { get; set; }
        public String FileName
        {
            get
            {
                return this.FileInfo.Name;
            }
        }
        public EntityTableInfo TableInfo { get; set; }
        public Boolean IsLegacy { get; set; }
    }
}
