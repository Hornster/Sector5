using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Console
{
    /// <summary>
    /// Influences behavior of the command window input area.
    /// </summary>
    public class InputFieldController : MonoBehaviour
    {
        [Tooltip("Ref to the field that is used for inputting commands into the console.")]
        [SerializeField]
        private TMP_InputField _inputField;

        private bool _isInputFocused;
        private bool _isSubmitPressed;

        public void ResetInput()
        {
            _inputField.text = "";
        }

        public void SubmitPressed()
        {
            _isSubmitPressed = true;
        }
        public void OnFocusGained(string inputValue)
        {
            _isSubmitPressed = false;
            _isInputFocused = true;
        }

        private void Start()
        {
            InputReader.RegisterSubmitEvent(SubmitPressed);
        }
        /// <summary>
        /// Checks if the focus was lost due to a submit action.
        /// If yes, makes the input become focused again.
        /// </summary>
        public void OnFocusLost(string inputValue)
        {
            if (_inputField.isActiveAndEnabled)
            {
                StartCoroutine(ChkIfSelectInput());
            }
        }

        private IEnumerator ChkIfSelectInput()
        {
            //The information about enter being pressed will arrive later - we need to
            //wait for it.
            yield return new WaitForEndOfFrame();
            if (_isInputFocused && _isSubmitPressed)
            {
                //Fool the input field into thinking that we clicked it again
                EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
                var pointerData = new PointerEventData(EventSystem.current);
                pointerData.button = PointerEventData.InputButton.Left;
                _inputField.OnPointerClick(pointerData);

                _isSubmitPressed = false;
            }
            else
            {
                _isSubmitPressed = false;
                _isInputFocused = false;
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }
}
