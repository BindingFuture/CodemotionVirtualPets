using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace VirtualPets.Scripts
{
    public class PetSpawner : MonoBehaviour
    {
        [FormerlySerializedAs("_pet")] [SerializeField]
        private GameObject pet;
        

        public void SpawnPet(Transform spawnTransform, Kind kind)
        {
            var instance = Instantiate(pet, spawnTransform);

            var petKind = instance.GetComponent<PetKind>();
            
            petKind.SetKind(kind);
        }
    }
}
