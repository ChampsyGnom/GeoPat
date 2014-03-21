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
    /// <summary>
    /// Service de traduction
    /// Tous les binding traductible on se service comme source
    /// Quand la langue change tous les bindings sont mis à jour en live :)
    /// </summary>
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

        /// <summary>
        /// Liste des resources de la langue actuelle
        /// </summary>
        public Dictionary<String, String> _ressources;

        /// <summary>
        /// Constante envoyé quand une resource n'est pas trouvé
        /// </summary>
        const string NotFoundError = "#StringNotFound#";

        /// <summary>
        /// Construteur , on initialise le dico des resources
        /// </summary>
        public TranslateService()
        {
            this._ressources = new Dictionary<string, string>();
        }
      
        /// <summary>
        /// Traduit du clé
        /// </summary>
        /// <param name="key">clé da la valeur</param>
        /// <returns>Valeur traduite ou contenu de NotFoundError si la clé n'est pas trouvé dans le dico des resources</returns>
        public string Tanslate(string key)
        {
            if (this._ressources == null)
            {this._ressources = new Dictionary<string, string>();}
            if (this._ressources.ContainsKey(key))
            { return this._ressources[key]; }
            else return NotFoundError+" - "+key;
        }
        /// <summary>
        /// Accesseur aux resources
        /// </summary>
        /// <param name="key">clé de la resources</param>
        /// <returns></returns>
        public String this[String key]
        {
            get 
            {
                return this.Tanslate(key);
            }
        }

        /// <summary>
        /// charge la langue courante au démarage du moteur
        /// </summary>
        public void Initialize()
        {
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<PrfLang> langs = dataService.GetDbSet<PrfLang>();
            DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
            this.LoadCurrentLang();
        }

        /// <summary>
        /// Change na langue courante et met à jour touts les bindings
        /// </summary>
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
