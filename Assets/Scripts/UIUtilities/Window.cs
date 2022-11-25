using System;
using UnityEngine;
using Zenject;

namespace Extentions.Menu
{
    public class Window : LazyGetComponent<CanvasGroup>
    {
        [SerializeField] private bool _pausesTheGame;
        
        private bool _opened;

        [Inject] private Pause Pause { get; set; }
        
        public event Action OnOpen;
        public event Action OnClose;
        
        public virtual void Open()
        {
            if ( ! TryToggleOpened(true))
                return;
            OnOpen?.Invoke();
            if (_pausesTheGame)
                Pause?.AddPauseSource(this);
                
        }

        public virtual void Close()
        {
            if ( ! TryToggleOpened(false))
                return;
            OnClose?.Invoke();
            if (_pausesTheGame)
                Pause?.RemoveSource(this);
        }

        private bool TryToggleOpened(bool opened)
        {
            if (_opened == opened)
                return false;
            
            _opened = opened;
            Lazy.blocksRaycasts = Lazy.interactable = opened;
            return true;
        }
    }
}