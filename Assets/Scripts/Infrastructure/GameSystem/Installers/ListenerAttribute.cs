using System;
using JetBrains.Annotations;

namespace Infrastructure.GameSystem.Installers
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ListenerAttribute : Attribute
    {
    
    }
}