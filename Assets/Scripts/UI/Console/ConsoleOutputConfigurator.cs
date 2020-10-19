using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.UI.Console
{
    public class ConsoleOutputConfigurator : MonoBehaviour
    {
        [Tooltip("Reference to the text control which should be modified.")]
        [SerializeField]
        private TMP_Text _textControl;
        [SerializeField]
        private RectTransform _transform;

        public void SetTextControl(string text, Color textColor)
        {
            _textControl.text = text;
            _textControl.color = textColor;
            _transform.ForceUpdateRectTransforms();
        }
    }
}
