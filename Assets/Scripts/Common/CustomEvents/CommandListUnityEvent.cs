using System;
using System.Collections.Generic;
using Assets.Scripts.Logic.Data;
using UnityEngine.Events;

namespace Assets.Scripts.Common.CustomEvents
{
    [Serializable]
    class CommandListUnityEvent : UnityEvent<List<Command>>
    {

    }
}