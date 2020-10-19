using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common.Data.ScriptableObjects
{
    /// <summary>
    /// Defines which receiver can use what command. That only means that the receiver can accept the command,
    /// whether are they able to execute it depends on themselves. For example, a drone can accept the interface command
    /// "int" but might not be able to execute it because of lack of an interface component.
    /// </summary>
    [CreateAssetMenu(fileName = "ReceiversCommandsConfigurationSO", menuName = "ScriptableObjects/Interpreter/ReceiversCommandsConfigurationSO", order = 5)]
    public class ReceiversCommandsConfigurationSO : ScriptableObject
    {
        [Tooltip("Stores info about what commands concern given receiver.")]
        [SerializeField]
        private CommandReceiversAvailableCommandsArrDictionary _commandsOfReceivers = new CommandReceiversAvailableCommandsArrDictionary();

        public Dictionary<CommandReceivers, SingleReceiverCommandsConfigSO> CommandsOfReceivers { get => _commandsOfReceivers.dictionary; }
    }
}
