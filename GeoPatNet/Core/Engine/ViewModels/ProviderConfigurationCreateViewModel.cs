using Emash.GeoPatNet.Infrastructure.Models;
using Emash.GeoPatNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    public class ProviderConfigurationCreateViewModel : IProviderConfigurationCreateViewModel
    {
        public String DisplayName { get; set; }
        private ProviderConfigurationType _selectedProviderConfigurationType;
        public ObservableCollection<ProviderParameter> ProviderParameters { get;private  set; }
        public ProviderConfigurationType SelectedProviderConfigurationType
        {
            get { return _selectedProviderConfigurationType; }
            set { _selectedProviderConfigurationType = value; this.CreateParameters(); }
        }

        private void CreateParameters()
        {
            this.ProviderParameters.Clear();
            if (this._selectedProviderConfigurationType != null)
            {
                foreach (ProviderParameter parameter in this._selectedProviderConfigurationType.ProviderParameters)
                {
                    ProviderParameter clone = parameter.Clone();
                    this.ProviderParameters.Add(clone);
                }
            }
        }
        public static List<ProviderConfigurationType> ProviderConfigurationTypes {
            get
            {return ProviderConfiguration.ProviderConfigurationTypes;} 
        }

        public ProviderConfigurationCreateViewModel()
        {
            this.ProviderParameters = new ObservableCollection<ProviderParameter>();
        }
    }
}
