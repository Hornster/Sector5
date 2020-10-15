using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Enums;
using UnityEngine;

namespace Assets.Scripts.Common.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CommandTypeInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/CommandTypeInterpreterConfigSO", order = 3)]
    public class CommandTypeInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("Stores available commands and strings that represent them.")]
        [SerializeField]
        private AvailableCommandsStringDictionary _knownCommands;

        public Dictionary<AvailableCommands, string> KnownCommands
        {
            get => _knownCommands.dictionary;
        }
    }
}
