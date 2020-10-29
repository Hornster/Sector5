using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class InterfaceController : Controller
{
    protected override void Initialize()
    {
        MyCommands = new List<AvailableCommands>() { AvailableCommands.Interface, AvailableCommands.ToggleDefenseSystems };
        WhoAmI = CommandReceivers.Interface;
    }

    protected override void Execute(InteractiveObject obj, Command command)
    {
        Interface interfaceObject = obj as Interface;

        if(interfaceObject == null)
        {
            //interface is not active
            return;
        }
        if(interfaceObject.IsActive == false)
        {
            //interface is not active
            return;
        }

        if(command.IssuedCommand == AvailableCommands.Interface)
        {
            if(interfaceObject.IsGained == true)
            {
                //no more resource czy cos
                return;
            }
                obj.Use();
        }
        else if(command.IssuedCommand == AvailableCommands.ToggleDefenseSystems)
        {
            interfaceObject.ToggleDefenseSystem();
        }
    }
}
