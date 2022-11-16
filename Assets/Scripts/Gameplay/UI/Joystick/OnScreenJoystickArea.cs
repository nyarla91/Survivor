using Extentions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI.Joystick
{
    public class OnScreenJoystickArea : Transformable, IPointerDownHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private OnScreenJoystick _tagetJoystick;

        public void OnPointerDown(PointerEventData eventData)
        {
            _tagetJoystick.OnBeginDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData) => _tagetJoystick.OnDrag(eventData);
        public void OnEndDrag(PointerEventData eventData) => _tagetJoystick.OnEndDrag(eventData);
    }
}