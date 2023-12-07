using System;
using JetBrains.Annotations;

namespace Scripts.Infrastructure.GameSystem.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ListenerAttribute : Attribute
    {
    
    }
}