using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Logic.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands.Interpreter
{
    public class ReceiverTypeInterpreter : MonoBehaviour, ICommandInterpreter 
    {
        /// <summary>
        /// Position of the receiver part of command among the values.
        /// </summary>
        private const int ReceiverPosition = 0;

        [Tooltip("Data about known receivers.")]
        [SerializeField]
        private ReceiverTypeInterpreterConfigSO _receiverTypeInterpreterConfigSO;
        private List<CommandReceivers> _allReceivers;

        private void Start()
        {
            _allReceivers = (Enum.GetValues(typeof(CommandReceivers)) as CommandReceivers[]).ToList();
        }
        /// <summary>
        /// Performs interpretation of the first argument of the command.
        /// Returns false and null if failed to interpret the value.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public (bool, Command) Interpret(List<string> input, Command command)
        {
            var knownReceivers = _receiverTypeInterpreterConfigSO.KnownReceivers;
            
            if (input.Count <= ReceiverPosition)
            {
                command = null;
                return (false, command);
            }
            var testedCommand = input[ReceiverPosition];
            for (int i = 0; i < _allReceivers.Count; i++)
            {
                //No TryGets - all of the positions need to be supplied to the ScriptableObject.
                //If something's missing - this shall scream in terror and pain.
                var knownCommand = knownReceivers[_allReceivers[i]];
                if (testedCommand.Contains(knownCommand))
                {
                    command.CommandReceiver = _allReceivers[i];

                    return (true, command);
                }
            }

            return (false, null);
        }
    }
}
