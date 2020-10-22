using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.Enums;

namespace Assets.Scripts.Logic.Data
{
    /// <summary>
    /// Container class used to pass reponse arguments to the console.
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// What type is the response of, and what color should be it displayed in?
        /// Details in enum file.
        /// </summary>
        public ConsoleOutputType ConsoleOutputType { get; set; }
        /// <summary>
        /// Prefix of the message. For example "ERR>" for error.
        /// Takes the color accordingly to value in ConsoleOutputType.
        /// </summary>
        public string MessagePrefix { get; set; }
        /// <summary>
        /// The main message to show. Takes the color accordingly to value in ConsoleOutputType.
        /// </summary>
        public string Message { get; set; }
    }
}
