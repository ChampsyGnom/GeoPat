using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Emash.GeoPatNet.Engine.ViewModels
{
    /// <summary>
    /// Modèlise une table parente dont les colonnes peuvent être ajouter à un affichage personalisé de sa fille
    /// </summary>
    /// <typeparam name="M">Type de lentité parente</typeparam>
    public class CustomDisplayableEntityViewModel<M>
    {
        /// <summary>
        /// Liste des champs pouvant être affiché
        /// </summary>
        public ObservableCollection<CustomDisplayablePropertyViewModel<M>> Fields { get; set; }
        /// <summary>
        /// Libellé de l'entité
        /// </summary>
        public String DisplayName { get; set; }
        /// <summary>
        /// Constructeur : On initialise la liste des champ
        /// </summary>
        public CustomDisplayableEntityViewModel()
        {
            this.Fields = new ObservableCollection<CustomDisplayablePropertyViewModel<M>>();
        }
    }
}
