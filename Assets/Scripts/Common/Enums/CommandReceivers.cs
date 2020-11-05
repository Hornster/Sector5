using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arguments that are available in the game.
/// </summary>
public enum CommandReceivers
{
    Drone,
    Airlock,
    Interface,
    /// <summary>
    /// Receiver that toggles the building design interface.
    /// </summary>
    Builder,
    /// <summary>
    /// Entity that builds walls.
    /// </summary>
    Constructor,
    /// <summary>
    /// Used only as default value.
    /// </summary>
    None
}
