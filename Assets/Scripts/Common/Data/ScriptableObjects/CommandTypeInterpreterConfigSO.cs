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
        [Tooltip("Stores available commands and strings that represent them. Implicit commands" +
            "that do not require command part itself should not be in here.")]
        [SerializeField]
        private AvailableCommandsStringDictionary _knownExplicitCommands = new AvailableCommandsStringDictionary();

        public Dictionary<AvailableCommands, string> KnownCommands
        {
            get => _knownExplicitCommands.dictionary;
        }
    }
}
