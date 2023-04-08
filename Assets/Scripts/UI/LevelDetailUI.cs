using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Color_Em_Up
{
    public class LevelDetailUI : GameUI
    {
        [field: SerializeField] public TextMeshProUGUI LevelDetailText { get; private set; }
        
        public override void Initialized()
        {
            base.Initialized();
        }

        public LevelDetailUI SetDetail(string _text)
        {
            LevelDetailText.SetText(_text);
            return this;
        }

        public IEnumerator ShowDetailFor(float _seconds)
        {
            Open();
            yield return new WaitForSeconds(_seconds);
            Close();
        }
        
        public override void Open(Action<GameUI> _openCompleted = null)
        {
            base.Open(_openCompleted);
        }
        
        public override void Close(Action<GameUI> _onCloseCompleted  = null)
        {
            base.Close(_onCloseCompleted);
        }
    }
}
