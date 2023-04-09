using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public interface ITarget
    {
        public void OnHitHandler(Bullet _bullet);
    }
}
