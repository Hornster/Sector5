using System.Collections.Generic;
using Assets.Scripts.Common.Enums;
using UnityEngine;


namespace Assets.Scripts.Logic.Data
{
    public class Command : MonoBehaviour
    {
        /// <summary>
        /// Who is the receiver of the command?
        /// </summary>
        public CommandReceivers CommandReceiver { get; set; }
        /// <summary>
        /// What is the ID of the receiver (if applicable)?
        /// </summary>
        public int ReceiverID { get; set; }
        /// <summary>
        /// What should the receiver do?
        /// </summary>
        public AvailableCommands IssuedCommand { get; set; }
        /// <summary>
        /// Arguments for the command (if applicable).
        /// </summary>
        public List<int> Args { get; set; }
    }
}
