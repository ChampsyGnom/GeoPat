using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using Emash.GeoPatNet.Infrastructure.Events;
using System.ComponentModel;

namespace Emash.GeoPatNet.Presentation.Services
{
    public class SplashService : ISplashService,INotifyPropertyChanged
    {
        public String Message { get; set; }
        public Int32 Progress { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public String Copyright { get; set; }
        private ManualResetEvent _resetEvent;
        private Thread _splashThread;
        private SplashView _splashView;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void ShowSplash(int maxTimeOut)
        {
            _resetEvent = new ManualResetEvent(false);
            _splashThread = new Thread(ShowSplash);
            _splashThread.SetApartmentState(ApartmentState.STA);
            _splashThread.IsBackground = true;
            _splashThread.Name = "Splash Screen";
            _splashThread.Start();
            _resetEvent.WaitOne();
            Console.WriteLine("_resetEvent ok ");
        }

         private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        public SplashService(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;            
            this._container = container;
            this._eventAggregator.GetEvent<SplashEvent>().Subscribe(OnSplashEvent);
            this.Message = "Initialisation ...";
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
        private Dispatcher Dispatcher { get; set; }
        private void ShowSplash()
        {
            this.Dispatcher = Dispatcher.CurrentDispatcher;
            _splashView = new SplashView();
            _splashView.Show();
            _splashView.Activate();            
            _resetEvent.Set();
            System.Windows.Threading.Dispatcher.Run();
        
      
        }

        private void OnSplashEvent(String message)
        {
            this.Dispatcher.Invoke(new Action(delegate()
            {
                this.Message = message;
                this.RaisePropertyChanged("Message");
            }));
        }
        public void CloseSplash(Action afterSplashClose)
        {
            this.Dispatcher.Invoke (new Action (delegate(){
                _splashView.Close();
            }));
          
           
           
        }
    }
}
