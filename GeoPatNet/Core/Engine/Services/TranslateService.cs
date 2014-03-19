using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.Engine.Services
{
    public class TranslateService : ITranslateService, INotifyPropertyChanged
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


        public Dictionary<String, String> _ressources;
        public TranslateService()
        {
            this._ressources = new Dictionary<string, string>();
        }
        const string NotFoundError = "#StringNotFound#";
        public string Tanslate(string key)
        {
            if (this._ressources == null)
            {this._ressources = new Dictionary<string, string>();}
            if (this._ressources.ContainsKey(key))
            { return this._ressources[key]; }
            else return NotFoundError+" - "+key;
        }
        public String this[String key]
        {
            get {
                return this.Tanslate(key);
            }
        }

        public void Initialize()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<PrfLang> langs = dataService.GetDbSet<PrfLang>();
            DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
            this.LoadCurrentLang();
        }


        public void LoadCurrentLang()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
            PrfParam paramDefaultLang = (from p in parameters where p.Code.Equals("LANG") select p).FirstOrDefault();
            String codeIso = "fra";
            if (paramDefaultLang != null)
            {codeIso = paramDefaultLang.Valeur;}
             DbSet<PrfLang> langs = dataService.GetDbSet<PrfLang>();
            this._ressources.Clear();
            List<PrfLang> currentLangs = (from l in langs where l.CodeIso.Equals (codeIso ) select l).ToList();
            foreach (PrfLang currentLang in currentLangs)
            {this._ressources.Add(currentLang.Key, currentLang.Valeur);}            
            this.RaisePropertyChanged("Item[]");
        }
    }
}
