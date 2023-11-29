using System;
using JetBrains.Annotations;

namespace Infrastructure.DI
{
    [AttributeUsage(AttributeTargets.Method)]
    [MeansImplicitUse]
    public sealed class InjectAttribute : Attribute
    {
    
    }
}