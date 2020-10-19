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
    /// Defines commands assigned to single receiver.
    /// </summary>
    [CreateAssetMenu(fileName = "SingleReceiverCommandsConfigSO", menuName = "ScriptableObjects/Interpreter/SingleReceiverCommandsConfigSO", order = 6)]
    public class SingleReceiverCommandsConfigSO : ScriptableObject
    {
        [Tooltip("The receiver that this object concerns.")]
        [SerializeField]
        private CommandReceivers _receiver;

        [Tooltip("All commands that the receiver mentioned by this object can take.")]
        [SerializeField]
        private AvailableCommands[] _commandsOfReceiver;

        public CommandReceivers Receiver { get => _receiver; }
        public AvailableCommands[] CommandsOfReceiver { get => _commandsOfReceiver; }
    }
}
