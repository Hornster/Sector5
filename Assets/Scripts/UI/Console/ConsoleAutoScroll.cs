using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Console
{
    public class ConsoleAutoScroll : MonoBehaviour
    {
        [Tooltip("The owner of the scrollbar that should be scrolled automatically.")]
        [SerializeField]
        private ScrollRect _scrollRect;
        [Tooltip("Should the bar be scrolled to the value of 0 or 1? TRUE for 0, FALSE for 1")]
        [SerializeField] private bool _scrollTo0;

        public void AutoScroll()
        {
            StartCoroutine(ApplyScrollPosition());

        }

        private IEnumerator ApplyScrollPosition()
        {
            yield return new WaitForEndOfFrame();

            LayoutRebuilder.ForceRebuildLayoutImmediate(_scrollRect.transform as RectTransform);
            if (_scrollTo0)
            {
                _scrollRect.verticalNormalizedPosition = 0.0f;
            }
            else
            {
                _scrollRect.verticalNormalizedPosition = 1.0f;
            }
        }
    }
}
