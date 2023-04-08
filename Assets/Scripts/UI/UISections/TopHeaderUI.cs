using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Color_Em_Up
{
    public class TopHeaderUI : GameUI
    {
        [field: SerializeField] public TextMeshProUGUI LevelText       { get; private set; }
        [field: SerializeField] public TextMeshProUGUI LevelDetailText { get; private set; }
        
        public WaveProgressBarUI WaveProgressBarUI;
        
        public override void Initialized()
        {
            base.Initialized();
        }

        public TopHeaderUI SetLevelUI(int _index)
        {
            LevelText.SetText($"LEVEL : {_index}");
            return this;
        }

        public TopHeaderUI SetLevelDetail(string _detail)
        {
            LevelDetailText.SetText(_detail);
            return this;
        }
        
        public override void Open(Action<GameUI> _openCompleted = null)
        {
         
        }
        
        public override void Close(Action<GameUI> _onCloseCompleted  = null)
        {
          
        }
    }
}
