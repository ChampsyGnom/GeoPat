﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Data.Models;
using DotSpatial.Controls;
using Emash.GeoPatNet.Modules.Carto.Layers;
using DotSpatial.Projections;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.Reflection;
using Emash.GeoPatNet.Infrastructure.Services;
using DotSpatial.Data;
using DotSpatial.Topology;

namespace Emash.GeoPatNet.Modules.Carto.ViewModels
{
    public abstract class CartoNodeLayerViewModel : CartoNodeViewModel
    {
        public DotSpatial.Controls.Map Map { get; set; }

        public abstract  LayerGroup LayerGroup { get; protected  set; }

       
              
        
        
        private Boolean _isChecked = true;

        public Boolean IsChecked
        {
            get { return _isChecked; }
            set 
            { 
                _isChecked = value;
                if (!_isChecked)
                {
                    if (this.Map != null && this.LayerGroup != null)
                    {
                        this.Map.MapFrame.SuspendEvents();
                        foreach (IMapLayer layer in this.LayerGroup)
                        {
                            if ( this.Map.Layers.Contains(layer))
                            { this.Map.Layers.Remove(layer); }
                        }
                        this.Map.MapFrame.ResumeEvents();
                    }
                }
                else
                {
                    this.Map.MapFrame.SuspendEvents();                  
                    this.Map.MapFrame.ResumeEvents();
                      
                }
               
               
                this.RaisePropertyChanged("IsChecked");
                
                
            }
        }
        public CartoNodeLayerViewModel(SigNode model)
            : base(model)
        {
            
        }
    }
}
