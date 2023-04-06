using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Color_Em_Up
{
    public class UIManager : AppManager
    {
        [SerializeField] private List<GameUI> GameUIs = new List<GameUI>();
        
        public Dictionary<Type, GameUI> GameUITable = new Dictionary<Type, GameUI>();

        public override void Initialized()
        {
            base.Initialized();
            
            GameUIs = FindObjectsOfType<GameUI>().ToList();
            
            foreach (var _ui in GameUIs)
                _ui.Initialized();
        }

        public T GetUI<T>() where T : GameUI
        {
            if (GameUITable.ContainsKey(typeof(T)))
            {
                return GameUITable[typeof(T)] as T;
            }

            return null;
        }

        public void Open<T>() where T : GameUI
        {
            var _ui = GetUI<T>();
            _ui.Open();
        }

        public void Close<T>() where T : GameUI
        {
            var _ui = GetUI<T>();
            _ui.Close();
        }

        public void Add(GameUI _ui)
        {
            if (!GameUITable.ContainsKey(_ui.GetType()))
                GameUITable.Add(_ui.GetType(), _ui);
            else
                GameUITable[_ui.GetType()] = _ui;
        }
        
        public void Remove(GameUI _ui)
        {
            if (GameUITable.ContainsKey(_ui.GetType()))
                GameUITable.Remove(_ui.GetType());
        }

        public void OpenAllUIs()
        {
            foreach (var _ui in GameUIs)
            {
                _ui.Open();
            }
        }

        public void CloseAllUIs()
        {
            foreach (var _ui in GameUIs)
            {
                _ui.Close();
            }
        }
        
        public void CloseAllUIs<T>()
        {
            foreach (var _ui in GameUIs)
            {
                if(_ui is T)
                    _ui.Close();
            }
        }
    }
}
