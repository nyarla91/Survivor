using System;
using Extentions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI.Joystick
{
    public class OnScreenJoystick : Transformable, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private bool _emulateFromKeyboard;
        [SerializeField] private RectTransform _edgePoint;
        [SerializeField] private OnScreenJoystickStick _stick;
        [SerializeField] [Range(0, 1)] private float _innerDeadZone;
        [SerializeField] [Range(0, 1)] private float _outerDeadZone;

        public event Action OnPress;
        public event Action<Vector2> OnRelease;
        
        private float _radius;
        private Vector2 _offset;

        private Vector2 KeyboardOffset => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        
        public Vector2 Offset => _offset.magnitude == 0 ? KeyboardOffset : _offset;

        private void Awake()
        {
            _radius = _edgePoint.localPosition.magnitude;
            _stick.OnPress += () => OnPress?.Invoke();
            _stick.OnRelease += () => OnRelease?.Invoke(_offset);
        }

        private void Update()
        {
            _offset = _stick.RectTransform.anchoredPosition / _radius;
            float offsetMagnitude = _offset.magnitude;
            if (offsetMagnitude < _innerDeadZone)
            {
                _offset = Vector2.zero;
            }
            else if (offsetMagnitude > _outerDeadZone)
            {
                _offset.Normalize();
                if (offsetMagnitude > 1)
                {
                    _stick.RectTransform.anchoredPosition = _offset.normalized * _radius;
                }
            }
        }

        private void OnValidate()
        {
            if (_outerDeadZone < _innerDeadZone)
                _outerDeadZone = _innerDeadZone;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _stick.OnBeginDrag(eventData);
            Transform.localPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData) => _stick.OnDrag(eventData);
        public void OnEndDrag(PointerEventData eventData) => _stick.OnEndDrag(eventData);
    }
}