using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Emash.GeoPatNet.Modules.Document.ViewModels
{
    public class DocumentViewModel : INotifyPropertyChanged
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
        public Boolean IsDefault { get; set; }
        public DocumentCodeViewModel Code { get; set; }
        public String AbsoluteFileName { get; set; }
        public String Libelle { get; set; }
        public Int64 Id { get; set; }
        public Visibility LoadingVisibility { get; set; }
        public Visibility ImageVisibility { get; set; }
        private ImageSource _image;
        private Task _task { get; set; }
        public ImageSource Image
        {
            get
            {
                if (this._image == null)
                {
                    LoadImage();
                   
                    
                }
                return this._image;
            }
        }
        private Dispatcher Dispatcher {get;set;}
        public DocumentViewModel()
        {
            this.ImageVisibility = Visibility.Hidden;
            this.LoadingVisibility = Visibility.Visible;
            this.Dispatcher = System.Windows.Application.Current.Dispatcher;
        }
        private void LoadImage()
        {
            FileInfo fileInfo = new FileInfo(this.AbsoluteFileName);
            String ext = fileInfo.Extension.Replace(".", "").ToLower();
            if (ext.EndsWith("bmp") || ext.EndsWith("jpeg") || ext.EndsWith("png") || ext.EndsWith("jpg") )
            {
                try
                {
                    FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open);
                    MemoryStream ms = new MemoryStream();
                    byte[] bytes = new byte[1024];
                    int read = 0;
                    while ((read = stream.Read(bytes, 0, 1024)) > 0)
                    { ms.Write(bytes, 0, read); }
                    stream.Close();
                    stream.Dispose();
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = ms;
                    image.EndInit();
                    image.Freeze();
                    ms.Dispose();
                    this._image = image;
                    this.LoadingVisibility = Visibility.Hidden;
                    this.ImageVisibility = Visibility.Visible;
                    this.RaisePropertyChanged("Image");
                    this.RaisePropertyChanged("LoadingVisibility");
                    this.RaisePropertyChanged("ImageVisibility");
                }
                catch (Exception ex)
                { }
                
                
              
               
            }
        }
    }
}
