using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Services;

using Emash.GeoPatNet.Infrastructure.Events;
using Microsoft.Practices.Prism.Events;
using Emash.GeoPatNet.Data.Models;

namespace Emash.GeoPatNet.Modules.Reperage.Services
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




        public long? PrToAbs(long chausseeId, string valuePr)
        {
            if (this.Reperes.ContainsKey (chausseeId ))
            {
                 List<InfRepere> chausseeReperes = this.Reperes[chausseeId];
                 if (String.IsNullOrEmpty(valuePr)) return null;
                 else
                 {
                     int num = 0;
                     int dplt = 0;
                     if (valuePr.IndexOf("+") == -1)
                     {
                         if (Int32.TryParse(valuePr.Trim(), out num))
                         {
                             InfRepere repere = (from r in chausseeReperes where r.Num == num select r).FirstOrDefault();
                             if (repere == null)
                             {
                                 InfRepere lastRepere = (from r in chausseeReperes orderby r.AbsCum descending select r).FirstOrDefault();
                                 if (num > lastRepere.Num)
                                 {
                                     int deltaNum = num - (int) lastRepere.Num;
                                     return lastRepere.AbsCum + lastRepere.Inter + (deltaNum * num);
                                 }
                                 else 
                                 {
                                     InfRepere firstRepere = (from r in chausseeReperes orderby r.AbsCum select r).FirstOrDefault();
                                     int deltaNum = (int)firstRepere.Num- num ;
                                     return lastRepere.AbsCum - (deltaNum * num);
                                     
                                 }
                             }
                             else return repere.AbsCum;
                         }
                         else
                         { return null; }
                     }
                     else
                     {
                         String[] items = valuePr.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                         if (items.Length == 1)
                         {
                             return this.PrToAbs(chausseeId, items[0]);
                         }
                         else
                         {

                             if (Int32.TryParse(items[0].Trim(), out num) && Int32.TryParse(items[1].Trim(), out dplt))
                             {
                                 InfRepere repere = (from r in chausseeReperes where r.Num == num select r).FirstOrDefault();
                                 if (repere == null)
                                 {
                                     InfRepere lastRepere = (from r in chausseeReperes orderby r.AbsCum descending select r).FirstOrDefault();
                                     if (num > lastRepere.Num)
                                     {
                                         int deltaNum = num - (int)lastRepere.Num;
                                         return lastRepere.AbsCum + lastRepere.Inter + (deltaNum * num);
                                     }
                                     else
                                     {
                                         InfRepere firstRepere = (from r in chausseeReperes orderby r.AbsCum select r).FirstOrDefault();
                                         int deltaNum = (int)firstRepere.Num - num;
                                         return lastRepere.AbsCum - (deltaNum * num);

                                     }
                                 }
                                 else
                                 {
                                     return repere.AbsCum + dplt;
                                 }
                             }
                             else
                             { return null; }
                         }
                     }
                 }
            }
            else
            {
                return this.PrToAbsVirtualized(valuePr);
               
            }
            
        }

        private long? PrToAbsVirtualized(string valuePr)
        {
            int num = 0;
            int dplt = 0;
            String[] items = valuePr.Split("+".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == 1)
            {

                if (Int32.TryParse(items[0].Trim(), out num))
                {
                    return num * 1000;
                }
                else
                { return null; }

            }
            else
            {
                if (Int32.TryParse(items[0].Trim(), out num) && Int32.TryParse(items[1].Trim(), out dplt))
                {
                    return (num * 1000) + dplt;
                }
                else
                { return null; }
            }
         
        }
    }
}
