using System;
using UnityEngine;

namespace VirtualPets.Scripts
{
    public class AndroidEscape : MonoBehaviour
    {
        private void Update()
        {
            if (Application.platform != RuntimePlatform.Android)
                return;

            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();
        }
    }
}