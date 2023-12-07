using System;
using JetBrains.Annotations;

namespace Scripts.Infrastructure.DI
{
    [AttributeUsage(AttributeTargets.Method)]
    [MeansImplicitUse]
    public sealed class InjectAttribute : Attribute
    {
    
    }
}