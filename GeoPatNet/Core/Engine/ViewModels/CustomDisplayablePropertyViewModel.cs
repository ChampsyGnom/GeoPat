using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Reflection;

namespace Emash.GeoPatNet.Engine.ViewModels
{
    /// <summary>
    /// Modèlise un champ affiché dans un formaulaire/Tableau
    /// </summary>
    /// <typeparam name="M"></typeparam>
    public class CustomDisplayablePropertyViewModel<M> : INotifyPropertyChanged
    {
        /// <summary>
        /// VM de l'entité conteant le champ
        /// </summary>
        public  CustomDisplayableEntityViewModel<M>  Entity { get; set; }
        /// <summary>
        /// Chemin du champ
        /// </summary>
        public String FieldPath { get; set; }
        /// <summary>
        /// Libellé de la propriété
        /// </summary>
        public String DisplayName { get; set; }
        /// <summary>
        /// Column Info sous jacente
        /// </summary>
        public EntityColumnInfo ColumnInfo { get; set; }
        /// <summary>
        /// True si l'utilisateur peut supprimer ce champ de l'affichage personalisé
        /// </summary>
        public Boolean CanRemove { get; set; }


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
        /// Notifie de tous les changement
        /// </summary>
        internal void RaiseChange()
        {
            this.RaisePropertyChanged("FieldPath");
            this.RaisePropertyChanged("Entity");
            this.RaisePropertyChanged("CanRemove");
            this.RaisePropertyChanged("ColumnInfo");
        }
    }
}
