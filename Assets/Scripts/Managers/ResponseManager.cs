using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.CustomEvents;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

class ResponseManager : Singleton<ResponseManager>
{
    [SerializeField]
    private CommandResponseUnityEvent _response;
    #region Universal Responses
    public void CommandNotRecognized(string prefix, string command)
    {
        string message = "Error! Command not recognized: " + command;
        _response?.Invoke(ErrorResponse(prefix, message));
    }

    public void ObjectNotExist(string prefix, string name)
    {
        string message = "Error! " + name + " does not exist";
        _response?.Invoke(ErrorResponse(prefix, message));
    }
    #endregion
    #region Drone Responses
    public void DroneMoveTo(string prefix, string destination)
    {
        string message = "Moving to " + destination;
        _response?.Invoke(PositiveResponse(prefix, message));
    }

    public void RoomNotExist(string prefix, string name)
    {
        string message = "Error! Room " + name + " does not exist!";
        _response?.Invoke(ErrorResponse(prefix, message));
    }

    public void PathBlocked(string prefix)
    {
        string message = "Path blocked";
        _response?.Invoke(WarningResponse(prefix, message));
    }

    public void ReachDestination(string prefix, string name)
    {
        string message = "Drone" + name + " reached target";
        _response?.Invoke(PositiveResponse(prefix, message));
    }
    public void DroneNotExist(string prefix, string name)
    {
        string message = "Error! Drone " + name + " does not exist";
        _response?.Invoke(ErrorResponse(prefix, message));
    }
    #endregion
    #region Interface Responses
    public void NoResources(string prefix)
    {
        string message = "Error! No more resources";
        _response?.Invoke(ErrorResponse(prefix, message));
    }

    public void GainedResources(string prefix, string info)
    {
        string message = "Gained " + info;
        _response?.Invoke(PositiveResponse(prefix, message));
    }

    public void InterfaceNotActive(string prefix)
    {
        string message = "Error! Interface not active";
        _response?.Invoke(ErrorResponse(prefix, message));
    }

    public void InterfaceState(string prefix,bool isActive)
    {
        string activeText = isActive ? "activated" : "deactivated";
        string message = $"Interface {activeText}";
        _response?.Invoke(PositiveResponse(prefix, message));
    }

    public void ToggleDefenseSystem(string prefix)
    {
        string message = "Toggle Defense System";
        _response?.Invoke(PositiveResponse(prefix, message));
    }
    #endregion
    #region Airlocks Responses
    public void AirlockNotExist(string prefix, string name)
    {
        string message = "Error! Airlock " + name + " does not exist";
        _response?.Invoke(ErrorResponse(prefix, message));
    }
    public void UsedAirlock(string prefix, string name)
    {
        string message = "Used airlock " + name;
        _response?.Invoke(PositiveResponse(prefix, message));
    }
    #endregion
    #region CommandResponse Types
    private CommandResponse ErrorResponse(string prefix, string message)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Error,
            MessagePrefix = prefix,
            Message = message
        };
    }

    private CommandResponse WarningResponse(string prefix, string message)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Warning,
            MessagePrefix = prefix,
            Message = message
        };
    }
    private CommandResponse PositiveResponse(string prefix, string message)
    {
        return new CommandResponse()
        {
            ConsoleOutputType = ConsoleOutputType.Positive,
            MessagePrefix = prefix,
            Message = message
        };
    }
    #endregion
}
