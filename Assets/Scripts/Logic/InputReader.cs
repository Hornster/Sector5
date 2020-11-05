using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Logic
{
    /// <summary>
    /// Used to check the input from the user.
    /// </summary>
    public class InputReader : MonoBehaviour
    {
        private static Keyboard _keyboard;
        private static UnityAction _submitEvent;

        private void Start()
        {
            _keyboard = Keyboard.current;
        }
        private void Update()
        {
            if (_keyboard.enterKey.wasPressedThisFrame)
            {
                _submitEvent?.Invoke();
            }
        }

        void OnDestroy()
        {
            _submitEvent = null;
        }
        public static void RegisterSubmitEvent(UnityAction handler)
        {
            _submitEvent += handler;
        }
    }
}
