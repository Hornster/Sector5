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
    /// <summary>
    /// Defines prefixes for arguments of commands, for example room 1 would have r prefix: r1.
    /// </summary>
    [CreateAssetMenu(fileName = "CommandArgInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/CommandArgInterpreterConfigSO", order = 3)]

    public class CommandArgInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("All known argument prefixes. Argumentless commands shall not be in here.")]
        [SerializeField]
        private AvailableCommandsStringDictionary _knownCommandsWithArguments = new AvailableCommandsStringDictionary();

        public Dictionary<AvailableCommands, string> CommandsWithArgs
        {
            get => _knownCommandsWithArguments.dictionary;
        }

    }
}
