using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emash.GeoPatNet.Infrastructure.Events;

namespace Emash.GeoPatNet.Engine.Services
{
    /// <summary>
    /// Service du moteur
    /// @TODO : reporter l'ouverture d'entité ici c'est plus logique
    /// </summary>
    public class EngineService : IEngineService
    {
        public IDialogService DialogService { get; private set; }

        public EngineService(IDialogService dialogService)
        {
            this.DialogService = dialogService;
        }
        /// <summary>
        /// Affiche une mode de dialogue de création d'entité générique et renvoie un objet de type T1 ou null
        /// </summary>
        /// <typeparam name="T1">Objet de type T1 si ok ou null si cancel</typeparam>
        /// <returns></returns>
        public T1 ShowAddDialog<T1>() where T1 : class, new()
        {
            GenericDataDialog window = new GenericDataDialog();
            GenericListViewModel<T1> vmList = new GenericListViewModel<T1>();
            T1 item = null;
            vmList.OnGenericListChange += delegate(object source, GenericListEventArg<T1> e)
            {
                if (e is GenericListCommitedEventArg<T1>)
                {
                    GenericListCommitedEventArg<T1> evt = (e as GenericListCommitedEventArg<T1>);
                    if (evt.CommitAction == Infrastructure.Enums.GenericCommitAction.Insert)
                    {
                        item = evt.CommitItem;
                        window.DialogResult = true;
                        window.Close();                        
                    }
                }
            };
            vmList.LockUnlockCommand.Execute();
            vmList.InsertCommand.Execute();           
            window.DataContext = vmList;
            window.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            Nullable<Boolean> result = window.ShowDialog();
            return item;
        }

       

        

        /// <summary>
        /// Affiche une boite d'édition générique d'entité
        /// </summary>
        /// <typeparam name="T1">Type de l'objet entity</typeparam>
        /// <param name="model">Objet</param>
        /// <returns></returns>
        public T1 ShowEditDialog<T1>(T1 model) where T1 : class, new()
        {
            GenericDataDialog window = new GenericDataDialog();
            GenericListViewModel<T1> vmList = new GenericListViewModel<T1>();
            T1 item = null;
            vmList.OnGenericListChange += delegate(object source, GenericListEventArg<T1> e)
            {
                if (e is GenericListCommitedEventArg<T1>)
                {
                    GenericListCommitedEventArg<T1> evt = (e as GenericListCommitedEventArg<T1>);
                    if (evt.CommitAction == Infrastructure.Enums.GenericCommitAction.Update)
                    {
                        item = evt.CommitItem;
                        window.DialogResult = true;
                        window.Close();
                    }
                }
            };
            vmList.SearchItem["Id"] = model.GetType().GetProperty("Id").GetValue(model).ToString();
            vmList.SearchCommand.Execute();
            vmList.LockUnlockCommand.Execute();
            window.DataContext = vmList;
            window.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            Nullable<Boolean> result = window.ShowDialog();
            return item;
            
        }


       /// <summary>
       /// Affiche une boite de dialogue d'ajout d'entité
       /// </summary>
       /// <typeparam name="T1">Type de l'entité</typeparam>
       /// <param name="model">Objet entité></param>
       /// <param name="fieldPaths">Liste des champs autorisé</param>
       /// <returns></returns>
        public T1 ShowAddDialog<T1>(T1 model, string[] fieldPaths) where T1 : class, new()
        {
            GenericDataDialog window = new GenericDataDialog();
            GenericListViewModel<T1> vmList = new GenericListViewModel<T1>();
            vmList.FieldPaths.Clear();
            foreach (String fieldPath in fieldPaths)
            { vmList.FieldPaths.Add(fieldPath); }
            T1 item = null;
            vmList.OnGenericListChange += delegate(object source, GenericListEventArg<T1> e)
            {
                if (e is GenericListCommitedEventArg<T1>)
                {
                    GenericListCommitedEventArg<T1> evt = (e as GenericListCommitedEventArg<T1>);
                    if (evt.CommitAction == Infrastructure.Enums.GenericCommitAction.Insert)
                    {
                        item = evt.CommitItem;
                        window.DialogResult = true;
                        window.Close();
                    }
                }
            };
            vmList.LockUnlockCommand.Execute();
            vmList.InsertCommand.Execute();
            vmList.InsertingItem.SetModel(model);
            window.DataContext = vmList;
            window.Owner = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.IsActive);
            Nullable<Boolean> result = window.ShowDialog();
            return item;
        }
    }
}
