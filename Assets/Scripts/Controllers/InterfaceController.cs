using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    public Interface interfaceScript;
    private AvailableCommands commandInterface = AvailableCommands.Interface;
    private AvailableCommands commandDef = AvailableCommands.ToggleDefenseSystems;
    private CommandReceivers _whoAmI = CommandReceivers.Interface;

    public void ReceiveCommand(List<Command> commands)
    {
        for (int i = 0; i < commands.Count; i++)
        {
            var currentlyProcessedCommand = commands[i];
            if (currentlyProcessedCommand.CommandReceiver != _whoAmI)
            {
                continue;
            }

            if(interfaceScript.IsActive == false)
            {
                ResponseManager.Instance.InterfaceNotActive(_whoAmI.ToString() + '>');
                continue;
            }

            if(currentlyProcessedCommand.IssuedCommand == commandInterface)
            {
                if(interfaceScript.IsGained == false)
                {
                    interfaceScript.GetResources();
                    ResponseManager.Instance.GainedResources(_whoAmI.ToString() + '>', "NavCoords: " + interfaceScript.NavCoordsReward);
                }
                else
                {
                    ResponseManager.Instance.NoResources(_whoAmI.ToString() + '>');
                }
            }
            else if(currentlyProcessedCommand.IssuedCommand == commandDef)
            {
                ResponseManager.Instance.ToggleDefenseSystem(_whoAmI.ToString() + '>');
            }
            else
            {
                ResponseManager.Instance.CommandNotRecognized(_whoAmI.ToString() + '>', currentlyProcessedCommand.IssuedCommand.ToString());
            }
        }
    }
}
