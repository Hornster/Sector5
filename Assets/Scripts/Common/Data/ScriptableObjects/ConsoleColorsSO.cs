using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using Assets.Scripts.Common.Enums;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Common.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ConsoleColorsSO", menuName = "ScriptableObjects/UI/ConsoleColors", order = 1)]
    public class ConsoleColorsSO : ScriptableObject
    {
        [Tooltip("Stores info about the colors available for given types of messages in the console.")]
        [SerializeField]
        private ConsoleOutputTypeColorDictionary _consoleColorsData = new ConsoleOutputTypeColorDictionary();

        //[Tooltip("Console text color for regular response.")]
        //[SerializeField]
        //private Color _regularResponseColor;
        //[Tooltip("Console text color for error response.")]
        //[SerializeField]
        //private Color _errorResponseColor;

        /// <summary>
        /// Retrieves proper color for the response type. If no color found, returns
        /// regular color.
        /// </summary>
        /// <param name="consoleConsoleOutputType"></param>
        /// <returns></returns>
        public Color GetConsoleColor(ConsoleOutputType consoleConsoleOutputType)
        {
            var consoleColors = _consoleColorsData.dictionary;
            if (consoleColors.TryGetValue(consoleConsoleOutputType, out var color))
            {
                return color;
            }

            return consoleColors[ConsoleOutputType.Regular];
        }
    }
}
