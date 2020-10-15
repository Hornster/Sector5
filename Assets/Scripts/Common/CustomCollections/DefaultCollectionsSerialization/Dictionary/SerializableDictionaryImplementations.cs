﻿//Taken from http://wiki.unity3d.com/index.php/SerializableDictionary
//Author: Fredrik Ludvigsen (Steinbitglis) 

//Modifications by: Karol Kozuch (CrazedAerialCable)

using System;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;

namespace Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary
{
    // ---------------
//  String => Int
// ---------------
    [Serializable]
    public class StringIntDictionary : SerializableDictionary<string, int> { }

// ---------------
//  GameObject => Float
// ---------------
    [Serializable]
    public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> { }

//KKozuch modifications

//---------------------
// ConsoleOutputType => Color
//---------------------
    /// <summary>
    /// Serializable dictionary type for two menu types.
    /// </summary>
    [Serializable]
    public class ConsoleOutputTypeColorDictionary : SerializableDictionary<ConsoleOutputType, Color> {}

    //---------------------
    // string => CommandReceivers
    //---------------------
    /// <summary>
    /// Serializable dictionary type for two menu types.
    /// </summary>
    [Serializable]
    public class CommandReceiverStringDictionary : SerializableDictionary<CommandReceivers, string> { }

    //---------------------
    // string => AvailableCommands
    //---------------------
    /// <summary>
    /// Serializable dictionary type for two menu types.
    /// </summary>
    [Serializable]
    public class AvailableCommandsStringDictionary : SerializableDictionary<AvailableCommands, string> { }
}