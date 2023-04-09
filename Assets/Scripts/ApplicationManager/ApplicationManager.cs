using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }

        private readonly Dictionary<string, AppManager> managerTable = new Dictionary<string, AppManager>();

        [SerializeField] private List<AppManager> Managers = new List<AppManager>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;

            foreach (var _manager in Managers)
            {
                _manager.Initialized();
            }
        }

        public IEnumerable<IReset> GetAllResetManagers()
        {
            foreach (var _manager in managerTable.Values)
            {
                if (_manager is IReset _reset)
                {
                    yield return _reset;
                }
            }
        }

        public T Get<T>() where T : AppManager
        {
            string _key = typeof(T).Name;
            
            if (!managerTable.ContainsKey(_key))
            {
                Debug.LogError($"{_key} not registered with {GetType().Name}");
                
                throw new InvalidOperationException();
            }

            return (T)managerTable[_key];
        }
        
        public void Register<T>(T _service) where T : AppManager
        {
            string _key = _service.GetType().Name;
            
            if (managerTable.ContainsKey(_key))
            {
                Debug.LogError($"Attempted to register service of type {_key} which is already registered with the {GetType().Name}.");
                return;
            }

            managerTable.Add(_key, _service);
        }

        public void Unregister<T>() where T : AppManager
        {
            string _key = typeof(T).Name;
            
            if (!managerTable.ContainsKey(_key))
            {
                Debug.LogError($"Attempted to unregister service of type {_key} which is not registered with the {GetType().Name}.");
                return;
            }

            managerTable.Remove(_key);
        }
    }
}
