using System;
using Extentions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI.Joystick
{
    public class OnScreenJoystickStick : Transformable, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Action OnPress;
        public Action OnRelease;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            OnPress?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransform.localPosition = eventData.position - (Vector2)transform.parent.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnRelease?.Invoke();
            RectTransform.localPosition = Vector3.zero;
        }
    }
}