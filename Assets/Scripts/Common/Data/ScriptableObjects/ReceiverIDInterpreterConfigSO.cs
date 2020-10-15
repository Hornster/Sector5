using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Common.Data.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ReceiverIDInterpreterConfigSO", menuName = "ScriptableObjects/Interpreter/ReceiverIDInterpreterConfigSO", order = 2)]

    public class ReceiverIDInterpreterConfigSO : ScriptableObject
    {
        [Tooltip("All receivers that require an id to be provided.")]
        [SerializeField]
        private CommandReceivers[] _idRequiringReceivers;

        public CommandReceivers[] IDRequiringReceivers
        {
            get => _idRequiringReceivers;
        }
    }
}
