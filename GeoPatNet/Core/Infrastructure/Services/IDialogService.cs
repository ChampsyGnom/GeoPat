using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface IDialogService
    {

        Window CreateDialog(String regionName, String title);
    }
}
