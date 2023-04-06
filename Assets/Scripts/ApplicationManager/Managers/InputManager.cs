using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class InputManager : AppManager
    {
        public PlayerInput PlayerInput;

        public override void Initialized()
        {
            base.Initialized();

            PlayerInput = new PlayerInput();
        }
    }
}
