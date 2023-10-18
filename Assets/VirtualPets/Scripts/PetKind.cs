using System;
using UnityEngine;

namespace VirtualPets.Scripts
{
    public enum Kind
    {
        Cat = 0,
        Dog = 1
    }
    
    public class PetKind : MonoBehaviour
    {
        [SerializeField]
        private GameObject catGameObject;

        [SerializeField]
        private GameObject dogGameObject;

        public void SetKind(Kind kind)
        {
            switch(kind)
            {
                case Kind.Cat:
                    dogGameObject.SetActive(false);
                    catGameObject.SetActive(true);
                    break;
                case Kind.Dog:
                    dogGameObject.SetActive(true);
                    catGameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }
    }
}
