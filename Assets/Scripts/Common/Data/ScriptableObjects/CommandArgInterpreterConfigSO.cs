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
    [CreateAssetMenu(fileName = "CommandArgInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/CommandArgInterpreterConfigSO", order = 3)]

    public class CommandArgInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("All known argument pre- and postfixes. Argumentless commands shall not be in here.")]
        [SerializeField]
        private AvailableCommandsStringDictionary _knownArguments;

        public Dictionary<AvailableCommands, string> KnownArguments
        {
            get => _knownArguments.dictionary;
        }

    }
}
