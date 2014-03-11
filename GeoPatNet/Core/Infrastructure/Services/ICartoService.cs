﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Data;

namespace Emash.GeoPatNet.Infrastructure.Services
{
    public interface ICartoService
    {
        void ShowCarto();
        IFeatureSet ReferenceFeatureSet { get; }
        void Initialize();
    }
}