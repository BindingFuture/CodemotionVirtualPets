using UnityEngine;

namespace VirtualPets.Scripts
{
    public class DebugLogger : MonoBehaviour
    {
        public void Log(object obj)
        {
            Debug.Log(obj);
        }
        
        public void LogString(string str)
        {
            Debug.Log(str);
        }
    }
}