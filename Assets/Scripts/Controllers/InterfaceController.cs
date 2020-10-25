using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public Interface interfaceScript;
    private AvailableCommands _myCommand = AvailableCommands.Interface;
    private CommandReceivers _whoAmI = CommandReceivers.Interface;

    [Tooltip("Used to yeet response to the console so user can see if we failed to execute the command or succeeded successfully.")]
    [SerializeField]
    private CommandResponseUnityEvent _response;

    public void ReceiveCommand(List<Command> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            var currentlyProcessedCommand = commands[i];
            if (currentlyProcessedCommand.CommandReceiver != _whoAmI)
            {
                continue;
            }

            if(currentlyProcessedCommand.IssuedCommand == _myCommand)
            {
                /*
                    if("int nav")//nie wiem kompletnie jak zapisac komendy interfejsu.

                */
                if(interfaceScript.IsActive == false)
                {
                    _response?.Invoke(InterfaceNoActive(currentlyProcessedCommand));
                    continue;
                }
                if(interfaceScript.IsGained == false)
                {
                    interfaceScript.GetResources();
                    _response?.Invoke(PositiveResponse(currentlyProcessedCommand,"NavCoords", interfaceScript.NavCoordsReward));
                }
                else
                {
                    _response?.Invoke(NoResources(currentlyProcessedCommand));
                }
            }
            else
            {
                _response?.Invoke(NegativeResponse(currentlyProcessedCommand));
            }
        }
    }


    private CommandResponse NegativeResponse(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Error: Command not recognized: {command.IssuedCommand.ToString()}!"
        };
    }

    private CommandResponse NoResources(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Error: No more resources!"
        };
    }

    private CommandResponse InterfaceNoActive(Command command)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Error: Interface  not active!"
        };
    }


    private CommandResponse PositiveResponse(Command command,string resourceName, float value)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = _whoAmI.ToString() + '>',
            Message = $"Gained {resourceName}: {value}."
        };
    }
}
