using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Logic.Data;
using UnityEngine.Events;

namespace Assets.Scripts.Common.CustomEvents
{
    [Serializable]
    public class CommandResponseUnityEvent : UnityEvent<CommandResponse>
    {
    }
}
