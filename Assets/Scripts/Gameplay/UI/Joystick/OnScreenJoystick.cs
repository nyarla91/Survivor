using System;
using Extentions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI.Joystick
{
    public class OnScreenJoystick : Transformable
    {
        [SerializeField] private bool _emulateFromKeyboard;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _edgePoint;
        [SerializeField] private RectTransform _stick;
        [SerializeField] [Range(0, 1)] private float _innerDeadZone;
        [SerializeField] [Range(0, 1)] private float _outerDeadZone;

        private float _radius;
        private Vector2 _offset;

        private Vector2 KeyboardOffset => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        
        public Vector2 Offset => _offset.magnitude == 0 ? KeyboardOffset : _offset;

        public void Show(Vector2 screenPoint)
        {
            _canvasGroup.alpha = 1;
            RectTransform.position = screenPoint;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
            _stick.anchoredPosition = Vector2.zero;
        }

        public void MoveStick(Vector2 screenPoint)
        {
            _stick.position = screenPoint;
        }

        private void Awake()
        {
            _radius = _edgePoint.localPosition.magnitude;
        }

        private void Update()
        {
            _offset = _stick.anchoredPosition / _radius;
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
                    _stick.anchoredPosition = _offset.normalized * _radius;
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
            Transform.localPosition = eventData.position;
        }
    }
}