using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace VirtualPets.Scripts
{
    public class PetDetector : MonoBehaviour
    {
        [SerializeField]
        private string raycastLayer = "Pets";
        
        [SerializeField]
        private Camera rayCamera;

        public UnityEvent<GameObject> onPetDetected = new UnityEvent<GameObject>();

        public UnityEvent<GameObject> onPetUndetected = new UnityEvent<GameObject>();

        private GameObject _lastDetectedPet;
    
        private void Awake()
        {
            if(!rayCamera)
                rayCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            var ray = rayCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if(Physics.Raycast(ray, out var hitInfo, 10000, LayerMask.GetMask(raycastLayer)))
            {
                if (_lastDetectedPet != hitInfo.transform.gameObject)
                {
                    _lastDetectedPet = hitInfo.transform.gameObject;
                    onPetDetected.Invoke(_lastDetectedPet);
                }
            }
            else
            {
                if (_lastDetectedPet)
                {
                    onPetUndetected.Invoke(_lastDetectedPet);
                    _lastDetectedPet = null;
                }
            }
        }
    }
}
