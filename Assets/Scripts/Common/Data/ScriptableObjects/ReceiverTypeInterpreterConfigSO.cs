using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Common.CustomCollections.DefaultCollectionsSerialization.Dictionary;
using UnityEngine;

namespace Assets.Scripts.Common.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ReceiverTypeInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/ReceiverTypeInterpreterConfigSO", order = 1)]
    public class ReceiverTypeInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("Commands for known receivers.")]
        [SerializeField]
        private CommandReceiverStringDictionary _knownReceivers = new CommandReceiverStringDictionary();

        public Dictionary<CommandReceivers, string> KnownReceivers
        {
            get => _knownReceivers.dictionary;
        }
    }
}
