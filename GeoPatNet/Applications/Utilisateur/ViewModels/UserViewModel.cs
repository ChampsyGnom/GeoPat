using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class UserViewModel : GenericListViewModel<PrfUser>
    {
        public DelegateCommand<PrfProfil> AddProfilCommand { get; private set; }
        public DelegateCommand<PrfUserProfil> RemoveProfilCommand { get; private set; }
        public ObservableCollection<PrfProfil> ProfilList { get; private set; }
        public Boolean CanAddProfil
        {
            get {
                return this.State == Infrastructure.Enums.GenericDataListState.Display && !this.IsLocked;
            }
        }

        public override void RaiseStateChange()
        {
            base.RaiseStateChange();
            this.RaisePropertyChanged("CanAddProfil");
        }
        public UserViewModel() : base()
        {
            DbSet<PrfProfil> profils = this.DataService.GetDbSet<PrfProfil>();
            this.ProfilList = new ObservableCollection<PrfProfil> ();
            foreach (PrfProfil profil in profils)
            {this.ProfilList.Add(profil);}
            this.AddProfilCommand = new DelegateCommand<PrfProfil>(AddProfilExecute);
            this.RemoveProfilCommand = new DelegateCommand<PrfUserProfil>(RemoveProfilExecute);
        }

        private void RemoveProfilExecute(PrfUserProfil userProfil)
        {
            if (userProfil != null && this.ItemsView.CurrentItem != null)
            {
                PrfUser user = (this.ItemsView.CurrentItem as GenericListItemViewModel<PrfUser>).Model;
                DbSet<PrfUserProfil> profilUsers = this.DataService.GetDbSet<PrfUserProfil>();
                profilUsers.Remove(userProfil);
                this.DataService.DataContext.SaveChanges();
                ObjectContext objectContext = ((IObjectContextAdapter)this.DataService.DataContext).ObjectContext;
                objectContext.Refresh(RefreshMode.ClientWins, user);

            }
        }
        private void AddProfilExecute(PrfProfil profil)
        {
            if (profil != null && this.ItemsView.CurrentItem != null)
            {
                PrfUser user = (this.ItemsView.CurrentItem as GenericListItemViewModel<PrfUser>).Model ;
                if ((from u in user.PrfUserProfils where u.PrfProfil.PrfSchema.Id  == profil.PrfSchema.Id select u).Any())
                {
                    MessageBox.Show("Cette utilisateur possède déja un profil pour le schéma "+profil.PrfSchema.Libelle );
                }
                else
                {
                    DbSet<PrfUserProfil> profilUsers = this.DataService.GetDbSet<PrfUserProfil>();
                    PrfUserProfil item = new PrfUserProfil();
                    item.PrfUserId   = user.Id;
                    item.PrfProfilId = profil.Id;
                    profilUsers.Add(item);
                    this.DataService.DataContext.SaveChanges();
                    ObjectContext objectContext = ((IObjectContextAdapter)this.DataService.DataContext).ObjectContext;
                    objectContext.Refresh(RefreshMode.ClientWins, user);
                }
            }
        }
    }
}
