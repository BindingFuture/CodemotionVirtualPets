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
           // TODO: complete this
        }
    }
}
