using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Color_Em_Up
{
    public class AppManager : MonoBehaviour
    {
        private ApplicationManager applicationManager;

        public virtual void Initialized()
        {
            applicationManager = ApplicationManager.Instance;
            applicationManager.Register(this);
        }
    }
}
