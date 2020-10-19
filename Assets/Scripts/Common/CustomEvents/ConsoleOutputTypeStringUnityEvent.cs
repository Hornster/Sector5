using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Common.CustomEvents
{
    [Serializable]
    public class ConsoleOutputTypeStringStringUnityEvent : UnityEvent<ConsoleOutputType, string, string>
    {
    }
}
