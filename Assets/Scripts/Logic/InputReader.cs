using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Logic
{
    /// <summary>
    /// Used to check the input from the user.
    /// </summary>
    public class InputReader : MonoBehaviour
    {
        private static UnityAction _submitEvent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
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
