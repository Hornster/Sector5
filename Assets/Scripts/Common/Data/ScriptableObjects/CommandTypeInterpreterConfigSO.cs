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
    /// Defines names of the commands in the console. For example, Interface command would be referred by the
    /// user by typing in 'int' into the console.
    /// </summary>
    [CreateAssetMenu(fileName = "CommandTypeInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/CommandTypeInterpreterConfigSO", order = 3)]
    public class CommandTypeInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("Stores available commands and strings that represent them. Implicit commands" +
            "that do not require command part itself should not be in here.")]
        [SerializeField]
        private AvailableCommandsStringDictionary _knownExplicitCommands = new AvailableCommandsStringDictionary();
        [Tooltip("Stores overrides for commands of command receivers that do not require command type argument. If given receiver of the command is not in here," +
                 " the default command type they will get is NoCommand. Read: Receiver gets by default this command if no other command is explicitly provided by the user.")]
        [SerializeField]
        private CommandReceiversAvailableCommandsDictionary _knownImplicitCommandsOverrides = new CommandReceiversAvailableCommandsDictionary();

        public Dictionary<AvailableCommands, string> KnownCommands
        {
            get => _knownExplicitCommands.dictionary;
        }

        public Dictionary<CommandReceivers, AvailableCommands> KnownImplicitCommandsOverrides
        {
            get => _knownImplicitCommandsOverrides.dictionary;
        }
    }
}
