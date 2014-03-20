using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Permissions;
namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderConfiguration
    {
        public static List<ProviderConfigurationType> ProviderConfigurationTypes { get; private set; }

        static ProviderConfiguration()
        {
           
            ProviderConfigurationTypes = new List<ProviderConfigurationType>();
            ProviderConfigurationType providerPostgre = new ProviderConfigurationType (typeof (NpgsqlFactory),"Postgre SQL");
            providerPostgre.AddParameter ("Adresse","HOST","127.0.0.1");
            providerPostgre.AddParameter ("Port","PORT","5432");
            providerPostgre.AddParameter ("Nom de L'instance","DATABASE","test");
            ProviderConfigurationTypes.Add (providerPostgre);
        }
        public List<ProviderConfigurationItem> Items { get; set; }
        public ProviderConfigurationItem DefaultItem
        {

            get
            {
                return (from i in Items where i.IsDefault == true select i).FirstOrDefault();
            
            }
        }
        public ProviderConfiguration()
        {
            this.Items = new List<ProviderConfigurationItem>();
        }

        public void Save()
        {
           
            RegistryKey companyKey = Registry.LocalMachine.OpenOrCreateCompanyKey();
            RegistryKey geoPatKey = companyKey.OpenOrCreateKey("GeoPat");
            RegistryKey configKey = geoPatKey.OpenOrCreateKey("Configuration");
            RegistryKey providersKey = configKey.OpenOrCreateKey("Providers");
            providersKey.Clear();
            for (int i = 0; i < this.Items.Count; i++)
            {
                String keyName = "Provider_" + (i + 1).ToString();
                RegistryKey providerKey = providersKey.OpenOrCreateKey(keyName);
                providerKey.SetValue("DisplayName", Items[i].DisplayName);
                providerKey.SetValue("ProviderFactoryTypeFulleName", Items[i].ProviderFactoryTypeFullName);
                providerKey.SetValue("IsDefault", Items[i].IsDefault.ToString().ToUpper());
                RegistryKey paramsKey = providerKey.OpenOrCreateKey("Parameters");
                for (int j = 0; j < Items[i].Parameters.Count; j++)
                {
                    String keyNameParam = "Parameter_" + (j + 1).ToString();
                    RegistryKey paramKey = paramsKey.OpenOrCreateKey(keyNameParam);
                    paramKey.SetValue("Code", Items[i].Parameters[j].Code);
                    paramKey.SetValue("Value", Items[i].Parameters[j].Value);
                }

            }
            
        }

        public void Load()
        {
            this.Items.Clear();
            RegistryKey companyKey = Registry.LocalMachine.OpenOrCreateCompanyKey();
            RegistryKey geoPatKey = companyKey.OpenOrCreateKey("GeoPat");
            RegistryKey configKey = geoPatKey.OpenOrCreateKey("Configuration");
            RegistryKey providersKey = configKey.OpenOrCreateKey("Providers");
            String[] providersKeyNames = providersKey.GetSubKeyNames();
            foreach (String providerKeyName in providersKeyNames)
            {
                RegistryKey providerKey = providersKey.OpenOrCreateKey(providerKeyName);
                ProviderConfigurationItem item = new ProviderConfigurationItem();
                item.DisplayName = providerKey.GetValue("DisplayName").ToString();
                item.IsDefault = providerKey.GetValue("IsDefault").ToString().ToUpper ().Equals ("TRUE");
                item.ProviderFactoryTypeFullName = providerKey.GetValue("ProviderFactoryTypeFulleName").ToString();
                RegistryKey parametersKey = providerKey.OpenOrCreateKey("Parameters");
                String[] parametersKeyNames = parametersKey.GetSubKeyNames();
                foreach (String parametersKeyName in parametersKeyNames)
                {
                    RegistryKey parameterKey = parametersKey.OpenOrCreateKey(parametersKeyName);
                    ProviderParameter parameter = new ProviderParameter("",parameterKey.GetValue("Code").ToString(), parameterKey.GetValue("Value").ToString());
                    item.Parameters.Add(parameter);

                }
                this.Items.Add(item);
            }
        }

        public string GetPasswordForLogin(ProviderConfigurationItem providerConfigurationItem, string userName)
        {
            return "";
        }

        public bool TryConnect(string userName, string passord)
        {
            Boolean success = false;
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(passord) || this.DefaultItem == null)
            { return false; }
            if (this.DefaultItem.ProviderFactoryTypeFullName.Equals("Npgsql.NpgsqlFactory"))
            {
                NpgsqlConnection connection = (NpgsqlConnection)NpgsqlFactory.Instance.CreateConnection();
                connection.ConnectionString = "HOST="+
                    (from p in this.DefaultItem.Parameters where p.Code.Equals ("HOST") select p.Value).FirstOrDefault ()+
                    ";PORT=" +
                    (from p in this.DefaultItem.Parameters where p.Code.Equals("PORT") select p.Value).FirstOrDefault() +
                    ";DATABASE=" +
                    (from p in this.DefaultItem.Parameters where p.Code.Equals("DATABASE") select p.Value).FirstOrDefault() +
                    ";USER ID=" + userName + ";PASSWORD=" + passord + ";PRELOADREADER=true;Timeout=4";
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    success = true; 
                    /*
                    NpgsqlCommand command = new NpgsqlCommand("SELECT * from inf.inf_chaussee", connection);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0));
                    }
                    success = true; 
                     * */
                }
                connection.Close();
                connection.Dispose();
            }


            return success;
        }

        public void SetLoginPassword(ProviderConfigurationItem providerConfigurationItem, string login, string passord)
        {
            
        }
    }
}
