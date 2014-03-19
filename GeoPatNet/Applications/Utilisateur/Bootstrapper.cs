using Emash.GeoPatNet.Infrastructure;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Engine;
using Emash.GeoPatNet.App.Utilisateur.ViewModels;
using Emash.GeoPatNet.App.Utilisateur.Views;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Data.Models;
using System.Reflection;
using Emash.GeoPatNet.Infrastructure.Reflection;
using System.Data.Entity;

namespace Emash.GeoPatNet.App.Utilisateur
{
    public class Bootstrapper : EngineBootstrapper<MainViewModel, MainView>
    {
        protected override void ConfigureContainer()
        {
           
            this.Container.RegisterType<ProfilMasterDetailView>(new ContainerControlledLifetimeManager ());
            this.Container.RegisterType<UserMatserDetailView>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ConfigurationView>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();
        }

        public override void InitializeApplication()
        {
            base.InitializeApplication();
            IDataService dataService = this.Container.TryResolve<IDataService>();
            
            DbSet<PrfSchema> schemas = dataService.GetDbSet<PrfSchema>();
            DbSet<PrfTable> tables = dataService.GetDbSet<PrfTable>();
            DbSet<PrfProfil> profils = dataService.GetDbSet<PrfProfil>();
            DbSet<PrfProfilTable> profilTables = dataService.GetDbSet<PrfProfilTable>();

            foreach (EntitySchemaInfo schemaInfo in dataService.SchemaInfos)
            {
                PrfSchema schema = (from s in schemas where s.Name.Equals(schemaInfo.SchemaName) select s).FirstOrDefault();
                if (schema == null)
                {
                    schema = new PrfSchema();
                    schema.Name = schemaInfo.SchemaName;
                    schema.Libelle = schemaInfo.SchemaName;
                    schemas.Add(schema);
                    dataService.DataContext.SaveChanges();
                }
                foreach (EntityTableInfo tableInfo in schemaInfo.TableInfos)
                {
                    PrfTable table = (from t in tables where t.Name.Equals(tableInfo.TableName) && t.PrfSchema.Id.Equals (schema.Id ) select t).FirstOrDefault();
                    if (table == null)
                    {
                        table = new PrfTable();
                        table.Name = tableInfo.TableName;
                        table.Libelle = tableInfo.DisplayName;
                        table.PrfSchemaId = schema.Id;
                        tables.Add(table);
                        dataService.DataContext.SaveChanges();
                    }
                }
            }
            foreach (PrfProfil profil in profils)
            {
                foreach (PrfTable table in profil.PrfSchema.PrfTables)
                {
                    PrfProfilTable profilTable = (from pt in profilTables where pt.PrfProfilId.Equals (profil.Id) && pt.PrfTableId .Equals (table .Id ) select pt).FirstOrDefault();
                    if (profilTable == null)
                    {
                        profilTable = new PrfProfilTable();
                        profilTable.PrfProfilId = profil.Id;
                        profilTable.PrfTableId = table.Id;
                        profilTable.Import = false;
                        profilTable.Write = false;
                        profilTables.Add(profilTable);
                        dataService.DataContext.SaveChanges();
                    }
                }
            }
            
        }

      
        
    }
}
