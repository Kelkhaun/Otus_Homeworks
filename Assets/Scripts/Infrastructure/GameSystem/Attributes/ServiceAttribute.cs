﻿using System;
using JetBrains.Annotations;

namespace Infrastructure.GameSystem.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceAttribute : Attribute
    {
        public readonly Type Contract;

        public ServiceAttribute(Type contract)
        {
            Contract = contract;
        }
    }
}