using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

public class AirlocksController : Controller
{
    protected override void Initialize()
    {
        MyCommands = new List<AvailableCommands>() { AvailableCommands.ToggleAirlock };
        WhoAmI = CommandReceivers.Airlock;
    }

    protected override void Execute(InteractiveObject obj, Command command)
    {
        obj.Use();
    }
}
