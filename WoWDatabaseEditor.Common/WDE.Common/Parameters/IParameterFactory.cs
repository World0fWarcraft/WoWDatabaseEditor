﻿using System;
using WDE.Module.Attributes;

namespace WDE.Common.Parameters
{
    [UniqueProvider]
    public interface IParameterFactory
    {
        IParameter<int> Factory(string type);
        bool IsRegistered(string type);
        void Register(string key, IParameter<int> parameter);
    }
}