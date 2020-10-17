using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands
{
    /// <summary>
    /// Used to check if parsed command has any sense in terms of receiver-command
    /// relationship. (For example, whether can an interface go to another room)
    /// </summary>
    public class CommandMeaningEvaluator : MonoBehaviour
    {
        [Tooltip("Configurates which receivers can perform what commands.")]
        [SerializeField]
        private ReceiversCommandsConfigurationSO _receiverCommandConfigSO;
        /// <summary>
        /// Checks if receiver of the command has doable by them command assigned. Returns TRUE if command is good.
        /// FALSE otherwise. Reason of failure is provided in Error field.
        /// command object.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool ValidateCommand(Command command)
        {
            var commandsOfReceivers = _receiverCommandConfigSO.CommandsOfReceivers;
            //No TryGets - every single receiver should be configured, even if they do
            //not have any command assigned. If that is the case, they should at least have
            //the NoCommand assigned. Yes, I'm a bad person. I know.
            var commandsForCurrentReceiver = commandsOfReceivers[command.CommandReceiver].CommandsOfReceiver;

            var commandToCheck = command.IssuedCommand;
            for(int i = 0; i < commandsForCurrentReceiver.Length; i++)
            {
                if(commandToCheck == commandsForCurrentReceiver[i])
                {
                    return true;
                }
            }
            command.CommandParseError = CommandError.LogicEvaluationErrorIncorrectCommandForReceiver;
            return false;
        }
        /// <summary>
        /// Checks if receiver of the command has doable by them command assigned in all provided commands. Validates all commands at once. Returns FALSE
        /// upon finding at least one error. TRUE if every single command is fine. Reason(s) is(are) provided in erroneous
        /// command object(s).
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public bool ValidateMultipleCommands(List<Command> commands)
        {
            bool areCommandsCorrect = true;
            for(int i = 0; i < commands.Count; i++)
            {
                if (ValidateCommand(commands[i]) == false)
                {
                    areCommandsCorrect = false;
                }
            }

            return areCommandsCorrect;
        }
    }
}
