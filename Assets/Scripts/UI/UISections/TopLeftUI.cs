using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class TopLeftUI : GameUI
    {
        public ScoreUI      ScoreUI;
        public PlayerLifeUI PlayerLifeUI;
        
        public override void Initialized()
        {
            base.Initialized();
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
