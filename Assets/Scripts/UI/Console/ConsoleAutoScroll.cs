using System;
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
        [Tooltip("The transform of the object that holds the content.")]
        [SerializeField]
        private RectTransform _scrolledContentTransform;
        [Tooltip("Reference to the scrollbar that will be automatically scrolled.")]
        [SerializeField]
        private Scrollbar _scrollBar;
        [Tooltip("Should the bar be scrolled to the value of 0 or 1? TRUE for 0, FALSE for 1")]
        [SerializeField] private bool _scrollTo0;

        public void AutoScroll()
        {
            Canvas.ForceUpdateCanvases();
            //_scrolledContentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _scrolledContentTransform.rect.height);
            //_scrolledContentTransform.ForceUpdateRectTransforms();
            //var pos =_scrolledContentTransform.position;
            //pos.y = pos.y + 0.00000001f;
            //_scrolledContentTransform.position = pos;
            if (_scrollTo0)
            {
                _scrollBar.value = 0.0f;
            }
            else
            {
                _scrollBar.value = 1.0f;
            }
            
        }
    }
}
