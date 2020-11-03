using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Console
{
    public class InputFieldController : MonoBehaviour
    {
        [Tooltip("Ref to the field that is used for inputting commands into the console.")]
        [SerializeField] 
        private TMP_InputField _inputField;


        public void ResetInput()
        {
            _inputField.text = "";
        }
    }
}
