using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Windows;
using System.Windows.Data;
namespace Emash.GeoPatNet.Infrastructure.MarkupExtensions
{
    /// <summary>
    /// Markup Extension qui peut être utiliser directement dans le XAML pour les chaines qui doivent être traduite
    /// Elle sont binder au service de traduction et change toute en même temp au changement de langue :)
    /// </summary>
    public class TranslateExtension : MarkupExtension
    {

        private string _key;
        /// <summary>
        /// Clé de l'élément à traduire
        /// </summary>
        [ConstructorArgument("key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="key">Clé de l'élément à traduire</param>
        public TranslateExtension(string key)
        {
            _key = key;
        }

        // constante affiché quand aucun service de lanue n'est disponible
        const string NoLangServiceError = "#NoLangService#";

        // Fournit la valeur au XAML
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // En design time ou renvoie la clé préfixé de #DesignTime#
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime)
            {
                return "#DesignTime#" + Key;
            }
            else
            {
                // On checrcher le service de langue
                IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                if (container != null)
                {
                    ITranslateService translateService = container.TryResolve<ITranslateService>();
                    if (translateService != null)
                    {
                        // On cré le binding
                        var binding = new Binding("[" + _key+"]")
                        {
                            Source = translateService,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                            Mode= BindingMode.OneWay 
                        }
                        ;
                        return binding.ProvideValue(serviceProvider);
               
                    }
                    return NoLangServiceError;
                }
                else return NoLangServiceError;
            }
        } 
    }
}
