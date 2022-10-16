using UnityEngine;

namespace Tool.Generic
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;
        public static T Instance => instance;

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else {
                Destroy(gameObject);
            }
        }
    
        public bool IsInitialized => instance != null;

        private void OnDestroy()
        {
            if(instance)
            {
                instance = null;
            }
        }
    }
}
