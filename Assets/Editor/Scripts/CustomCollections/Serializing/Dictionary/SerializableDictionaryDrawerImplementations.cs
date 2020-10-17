//Taken from http://wiki.unity3d.com/index.php/SerializableDictionary
//Author: Fredrik Ludvigsen (Steinbitglis) 

//Modifications by: Karol Kozuch (CrazedAerialCable)

using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Enums;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.CustomCollections.Serializing.Dictionary
{
    // ---------------
    //  String => Int
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(StringIntDictionary))]
    public class StringIntDictionaryDrawer : SerializableDictionaryDrawer<string, int>
    {
        protected override SerializableKeyValueTemplate<string, int> GetTemplate()
        {
            return GetGenericTemplate<SerializableStringIntTemplate>();
        }
    }
    internal class SerializableStringIntTemplate : SerializableKeyValueTemplate<string, int> { }

    // ---------------
    //  GameObject => Float
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(GameObjectFloatDictionary))]
    public class GameObjectFloatDictionaryDrawer : SerializableDictionaryDrawer<GameObject, float>
    {
        protected override SerializableKeyValueTemplate<GameObject, float> GetTemplate()
        {
            return GetGenericTemplate<SerializableGameObjectFloatTemplate>();
        }
    }
    internal class SerializableGameObjectFloatTemplate : SerializableKeyValueTemplate<GameObject, float> { }

    //KKozuch modifications

    //---------------------
    // ConsoleOutputType => Color
    //---------------------
    /// <summary>
    /// Drawer for MenuType=>MenuType dictionary.
    /// </summary>
    [UnityEditor.CustomPropertyDrawer(typeof(ConsoleOutputTypeColorDictionary))]
    public class MenuTypeMenuTypeDictionaryDrawer : SerializableDictionaryDrawer<ConsoleOutputType, Color>
    {
        protected override SerializableKeyValueTemplate<ConsoleOutputType, Color> GetTemplate()
        {
            return GetGenericTemplate<SerializableMenuTypeMenuTypeTemplate>();
        }
    }

    internal class SerializableMenuTypeMenuTypeTemplate : SerializableKeyValueTemplate<ConsoleOutputType, Color> { }

    //---------------------
    // string => CommandReceivers
    //---------------------
    /// <summary>
    /// Drawer for MenuType=>MenuType dictionary.
    /// </summary>
    [UnityEditor.CustomPropertyDrawer(typeof(CommandReceiverStringDictionary))]
    public class CommandReceiverStringDictionaryDrawer : SerializableDictionaryDrawer<CommandReceivers, string>
    {
        protected override SerializableKeyValueTemplate<CommandReceivers, string> GetTemplate()
        {
            return GetGenericTemplate<CommandReceiverStringTemplate>();
        }
    }

    internal class CommandReceiverStringTemplate : SerializableKeyValueTemplate<CommandReceivers, string> { }

    //---------------------
    // string => AvailableCommands
    //---------------------
    /// <summary>
    /// Drawer for MenuType=>MenuType dictionary.
    /// </summary>
    [UnityEditor.CustomPropertyDrawer(typeof(AvailableCommandsStringDictionary))]
    public class AvailableCommandsStringDictionaryDrawer : SerializableDictionaryDrawer<AvailableCommands, string>
    {
        protected override SerializableKeyValueTemplate<AvailableCommands, string> GetTemplate()
        {
            return GetGenericTemplate<AvailableCommandsStringTemplate>();
        }
    }

    internal class AvailableCommandsStringTemplate : SerializableKeyValueTemplate<AvailableCommands, string> { }

    //---------------------
    // ReceiverType => AvailableCommands[]
    //---------------------
    /// <summary>
    /// Drawer for ReceiverType=>AvailableCommands[] dictionary.
    /// </summary>
    [UnityEditor.CustomPropertyDrawer(typeof(CommandReceiverAvailableCommandsArrDictionary))]
    public class CommandReceiverAvailableCommandsArrDictionaryDrawer : SerializableDictionaryDrawer<CommandReceivers, AvailableCommands[]>
    {
        protected override SerializableKeyValueTemplate<CommandReceivers, AvailableCommands[]> GetTemplate()
        {
            return GetGenericTemplate<CommandReceiverAvailableCommandsArrDictionary>();
        }
    }

    internal class CommandReceiverAvailableCommandsArrDictionary : SerializableKeyValueTemplate<CommandReceivers, AvailableCommands[]> { }
}
