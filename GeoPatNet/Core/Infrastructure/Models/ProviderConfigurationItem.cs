using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emash.GeoPatNet.Infrastructure.Models
{
    public class ProviderConfigurationItem
    {
        public List<ProviderParameter> Parameters { get;private  set; }
        public String DisplayName { get; set; }
        public Boolean IsDefault { get; set; }
        public String ProviderFactoryTypeFullName { get; set; }

        public ProviderConfigurationItem()
        {
            this.Parameters = new List<ProviderParameter>();
        }

        internal string GetHash()
        {
            return CalculateMD5Hash(this.DisplayName + "-" + this.ProviderFactoryTypeFullName + "-" + String.Join("-", (from p in this.Parameters select "aparam-" + p.Code + "-" + p.Value)));
        }
        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
