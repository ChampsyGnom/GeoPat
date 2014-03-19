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
namespace Emash.GeoPatNet.Engine.MarkupExtensions
{
    public class TranslateExtension : MarkupExtension
    {

        private string _key;
        [ConstructorArgument("key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
 
        public TranslateExtension(string key)
        {
            _key = key;
        }

        const string NoLangServiceError = "#NoLangService#";

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime)
            {
                return "#DesignTime#" + Key;
            }
            else
            {
                IUnityContainer container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                if (container != null)
                {
                    ITranslateService translateService = container.TryResolve<ITranslateService>();
                    if (translateService != null)
                    {
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
