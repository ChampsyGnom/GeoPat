﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Data.Implementation.Models;
using Emash.GeoPatNet.Data.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using Microsoft.Practices.Prism.Events;

namespace Emash.GeoPatNet.Reperage.Implementation.Services
{
    public class ReperageService : IReperageService
    {
        private Dictionary<Int64, List<InfRepere>> Reperes { get; set; }
        private IDataService _dataService;
        private IEventAggregator _eventAggregator;
        public ReperageService(IEventAggregator eventAggregator, IDataService dataService)
        {
            this._dataService = dataService;
            this._eventAggregator = eventAggregator;
         }

        public void Initialize()
        {
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du réperage ...");
            this.Reperes = new Dictionary<Int64, List<InfRepere>>();
            DbSet<InfRepere> reperes = _dataService.GetDbSet<InfRepere>();
            foreach (InfRepere repere in reperes)
            {
                if (!this.Reperes.ContainsKey(repere.InfChausseeId))
                { this.Reperes.Add(repere.InfChausseeId, new List<InfRepere>()); }
                this.Reperes[repere.InfChausseeId].Add(repere);
            }
        }

        public String AbsToPr(Int64 chausseeId, Nullable<Int64> abs)
        {

            if (abs.HasValue)
            {
                if (this.Reperes.ContainsKey(chausseeId))
                {
                    List<InfRepere> chausseeReperes = this.Reperes[chausseeId];
                    InfRepere repere = (from r in chausseeReperes where abs.Value >= r.AbsCum && abs.Value < (r.AbsCum + r.Inter) select r).FirstOrDefault();
                    if (repere != null)
                    {
                        int dplt =(int) ( abs.Value - repere.AbsCum);
                        return repere.Num.ToString() + " +" + dplt.ToString("0000");
                    }
                    else
                    {
                        InfRepere lastRepere =  (from r in chausseeReperes orderby r.AbsCum descending  select r).FirstOrDefault ();
                        if (abs.Value >= (lastRepere.Inter + lastRepere.AbsCum))
                        {
                            double detlaAbs = abs.Value - (lastRepere.Inter + lastRepere.AbsCum);
                            int deltaNum =(int)  Math.Floor(detlaAbs / 1000D);
                            int dplt =(int) ( detlaAbs - (deltaNum * 1000));
                            int num =(int) ( lastRepere.Num + 1 + deltaNum);
                            return num.ToString() + " +" + dplt.ToString("0000");                        
                        }
                        else
                        {
                            InfRepere firstRepere = (from r in chausseeReperes orderby r.AbsCum  select r).FirstOrDefault();
                            if (abs.Value < firstRepere.AbsCum)
                            {
                                double detlaAbs = firstRepere.AbsCum - abs.Value;
                                int deltaNum = (int)Math.Floor(detlaAbs / 1000D);
                                int dplt = (int)(detlaAbs - (deltaNum * 1000));
                                int num = (int)(lastRepere.Num - deltaNum);
                                return num.ToString() + " +" + dplt.ToString("0000");       
                           
                            }
                            else throw new Exception("Invalid repere");
                        
                        }

                    }
                   
                }
                else return this.AbsToPrVirtualized(abs.Value);
            }
            else return null;
        }

        private string AbsToPrVirtualized(long abs)
        {
            int num = (int) (Math.Floor((double)abs / 1000D));
            int dplt = (int)((double)abs - ((double)num * 1000D));
            return num.ToString() + " +" + dplt.ToString("0000");
        }

      
    }
}