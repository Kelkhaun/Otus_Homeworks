﻿using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Installers
{
    public sealed class TimeScaleListenerInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private TimeScaleListener _timeScaleListener;
            
        public List<IGameListener> Install()
        {
            var listeners = new List<IGameListener>
            {
                _timeScaleListener,
            };

            return listeners;
        }
    }
}