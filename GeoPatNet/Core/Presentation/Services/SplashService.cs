using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.Presentation.Services
{
    public class SplashService : ISplashService, INotifyPropertyChanged,IDisposable
    {
        public ManualResetEvent _splashResetEvent;
        public String Message { get; set; }
        public Int32 Progress { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public String Copyright { get; set; }
        public Action AfterSplashClose { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged( string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public SplashService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;            
            this._container = container;
            this.Message = "Initialisation ...";
            this._eventAggregator.GetEvent<SplashEvent>().Subscribe(OnSplashEvent);
            AssemblyDescriptionAttribute descriptionAttribute = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute)).FirstOrDefault() as AssemblyDescriptionAttribute;
            AssemblyTitleAttribute titleAttribute = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute)).FirstOrDefault() as AssemblyTitleAttribute;
          this.Version =  System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            AssemblyCompanyAttribute companyAttribute = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute)).FirstOrDefault() as AssemblyCompanyAttribute;
            AssemblyCopyrightAttribute copyrightAttribute = System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute)).FirstOrDefault() as AssemblyCopyrightAttribute;

            
            if (titleAttribute != null)
            { this.Title = titleAttribute.Title; }

            if (descriptionAttribute != null)
            { this.Description = descriptionAttribute.Description; }

            if (copyrightAttribute != null)
            { this.Copyright = copyrightAttribute.Copyright; }


            
        }
        private void OnSplashEvent(String message)
        {
            _dispatcher.Invoke(new Action(delegate()
            {
                this.Message = message;
                this.RaisePropertyChanged("Message");
            }));
        }
        private SplashView _splashView;
        private Task _splashTask;
        private int _maxTimeOut;
        private Dispatcher _dispatcher;
        public void ShowSplash(int maxTimeOut)
        {
            
            _splashResetEvent = new ManualResetEvent(false);
            _dispatcher = System.Windows.Application.Current.Dispatcher;
            _maxTimeOut = maxTimeOut;
            _splashView = new SplashView();
            _splashView.Show();
            _splashTask = new Task (RunSplash);
            _splashTask.Start ();

        }
        public void CloseSplash(Action afterSplashClose)
        {
            this.AfterSplashClose = afterSplashClose;
            _splashResetEvent.Set();
        }

        private void RunSplash()
        {
           
            
                _splashResetEvent.WaitOne();
                _dispatcher.Invoke(new Action(delegate()
                {
                    Message = "Démarrage ...";
                    this.RaisePropertyChanged("Message");
                }));
                int msPerPercent =(int) ((double ) this._maxTimeOut / 100.0D);

                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(msPerPercent);
                    _dispatcher.Invoke(new Action(delegate()
                    {
                        Progress = i;                       
                        this.RaisePropertyChanged("Progress");
                    }));

                } 

                _dispatcher.Invoke(new Action(delegate()
                {
                    Progress = 100;
                    this.RaisePropertyChanged("Progress");
                }));
              
                _dispatcher.Invoke(new Action(delegate()
                {
                    _splashView.Close();
                    if (this.AfterSplashClose != null)
                    { this.AfterSplashClose(); }
                }));
        }
        
       

        public void Dispose()
        {
            if (this._splashTask != null)
            { this._splashTask.Dispose(); }
            if (this._splashResetEvent != null)
            { _splashResetEvent.Dispose(); }
            GC.SuppressFinalize(this);
        }
    }
}
