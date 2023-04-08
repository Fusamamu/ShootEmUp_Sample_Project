using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEngine;

namespace Color_Em_Up
{
    public class PlayerLifeUI : MonoBehaviour
    {
        [SerializeField] private List<MPImage> LifeIcons = new List<MPImage>();

        public void IncreaseLife()
        {
            
        }

        public void DecreaseLife()
        {
            for (var _i = LifeIcons.Count -1 ; _i >= 0; _i--)
            {
                if(!LifeIcons[_i].gameObject.activeSelf)
                    continue;
                
                LifeIcons[_i].gameObject.SetActive(false);
                break;
            }
        }

        public void Reset()
        {
            foreach (var _icon in LifeIcons)
            {
                _icon.gameObject.SetActive(true);
            }
        }
    }
}
