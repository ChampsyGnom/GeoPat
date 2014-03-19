using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using Emash.GeoPatNet.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace Emash.GeoPatNet.App.Utilisateur.ViewModels
{
    public class ConfigurationSchemaViewModel
    {
        public PrfSchema Model { get; private set; }
        private String _directoryDocument;


        public String DirectoryDocument
        {
            get { return _directoryDocument; }
            set
            { 
                _directoryDocument = value;
                if (_directoryDocument != null)
                {
                    IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                    DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
                    PrfParam parameter = (from p in parameters
                                          where p.PrfSchemaId.HasValue &&
                                                   p.PrfSchemaId.Value.Equals(this.Model.Id) &&
                                                   p.Code.Equals("DIRECTORY_DOC")
                                               select p).FirstOrDefault();
                    if (parameter == null)
                    {
                        parameter = new PrfParam();
                        parameter.PrfSchemaId = this.Model.Id;
                        parameter.Code = "DIRECTORY_DOC";
                        parameters.Add(parameter);
                    }
                    parameter.Valeur = _directoryDocument;
                    dataService.DataContext.SaveChanges();
                }
            }
        }
        private String _directoryLog;


        public String DirectoryLog
        {
            get { return _directoryLog; }
            set {
                _directoryLog = value;
                if (_directoryLog != null)
                {
                    IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                    DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
                    PrfParam parameter = (from p in parameters
                                          where p.PrfSchemaId.HasValue &&
                                              p.PrfSchemaId.Value.Equals(this.Model.Id) &&
                                              p.Code.Equals("DIRECTORY_LOG")
                                          select p).FirstOrDefault();
                    if (parameter == null)
                    {
                        parameter = new PrfParam();
                        parameter.PrfSchemaId = this.Model.Id;
                        parameter.Code = "DIRECTORY_LOG";
                        parameters.Add(parameter);
                    }
                    parameter.Valeur = _directoryLog;
                    dataService.DataContext.SaveChanges();
                }
            }
        }
        private String _directoryData;


        public String DirectoryData
        {
            get { return _directoryData; }
            set { 
                _directoryData = value;
                if (_directoryData != null)
                {
                    IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
                    DbSet<PrfParam> parameters = dataService.GetDbSet<PrfParam>();
                    PrfParam parameter = (from p in parameters
                                          where  p.PrfSchemaId.HasValue && 
                                              p.PrfSchemaId.Value.Equals(this.Model.Id) &&
                                              p.Code.Equals("DIRECTORY_DATA")
                                          select p).FirstOrDefault();
                    if (parameter == null)
                    {
                        parameter = new PrfParam();
                        parameter.PrfSchemaId = this.Model.Id;
                        parameter.Code = "DIRECTORY_DATA";
                        parameters.Add(parameter);
                    }
                    parameter.Valeur = _directoryData;
                    dataService.DataContext.SaveChanges();
                }
            }
        }

        public ConfigurationSchemaViewModel(PrfSchema model)
        {
            this.Model = model;
            IDataService dataService = ServiceLocator.Current.GetInstance<IDataService>();
            DbSet<PrfParam> parameters = dataService.GetDbSet <PrfParam>();
            if ((from p in parameters
                 where  p.PrfSchemaId.HasValue && 
                      p.PrfSchemaId.Value.Equals(model.Id) &&
                      p.Code.Equals("DIRECTORY_DOC")
                 select p).Any())
            {
                this._directoryDocument = (from p in parameters
                                           where p.PrfSchemaId.HasValue && 
                                               p.PrfSchemaId.Value.Equals(model.Id) &&
                                               p.Code.Equals("DIRECTORY_DOC")
                                           select p.Valeur).FirstOrDefault();
            }


            if ((from p in parameters
                 where p.PrfSchemaId.HasValue && 
                      p.PrfSchemaId.Value.Equals(model.Id) &&
                      p.Code.Equals("DIRECTORY_LOG")
                 select p).Any())
            {
                this._directoryLog = (from p in parameters
                                      where p.PrfSchemaId.HasValue && 
                                      p.PrfSchemaId.Value.Equals(model.Id) &&
                                      p.Code.Equals("DIRECTORY_LOG")
                                      select p.Valeur).FirstOrDefault();
            }

            if ((from p in parameters
                 where p.PrfSchemaId.HasValue && 
                      p.PrfSchemaId.Value.Equals(model.Id) &&
                      p.Code.Equals("DIRECTORY_DATA")
                 select p).Any())
            {
                this._directoryData = (from p in parameters
                                       where p.PrfSchemaId.HasValue && 
                p.PrfSchemaId.Value.Equals(model.Id) &&
                p.Code.Equals("DIRECTORY_DATA")
                select p.Valeur).FirstOrDefault();
            }

          
            
           

        
        }
    }
}
