using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.Data.ScriptableObjects;
using Assets.Scripts.Common.Enums;
using Assets.Scripts.Logic.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI.Console
{
    public class ConsoleOutput : MonoBehaviour
    {
        [Tooltip("Provides color scheme of the text in the console.")]
        [SerializeField]
        private ConsoleColorsSO _consoleColors;
        [Tooltip("Prefab used to spawn the response in the output part of the console window.")]
        [SerializeField]
        private GameObject _consoleOutputTextPrefab;
        [Tooltip("The container gameobject that groups all of the console outputs.")]
        [SerializeField] 
        private Transform _responseContainerTransform;

        [Tooltip("Called whenever the console prints the output.")]
        [SerializeField] 
        private UnityEvent _onPrintMessage;

        /// <summary>
        /// Prints provided message.
        /// </summary>
        /// <param name="response"></param>
        public void PrintMessage(CommandResponse response)
        {
            PrintMessage(response.ConsoleOutputType, response.MessagePrefix, response.Message);
        }
        /// <summary>
        /// Prints provided message.
        /// </summary>
        /// <param name="consoleOutputType">What is the type of the response and what color should be it in?
        /// Details in enum file.</param>
        /// <param name="messagePrefix">Prefix input before the main message. Will take the color accordingly to consoleOutputType.</param>
        /// <param name="message">Main message to display. Will take the color accordingly to consoleOutputType.</param>
        public void PrintMessage(ConsoleOutputType consoleOutputType, string messagePrefix, string message)
        {
            var messageToShow = messagePrefix + message;
            var newResponse = Instantiate(_consoleOutputTextPrefab, _responseContainerTransform);
            var textControlConfigurator = newResponse.GetComponentInChildren<ConsoleOutputConfigurator>();
            var responseColor = _consoleColors.GetConsoleColor(consoleOutputType);

            textControlConfigurator.SetTextControl(messageToShow, responseColor);

            _onPrintMessage?.Invoke();
        }
    }
}
