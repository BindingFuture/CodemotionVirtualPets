using RandomNameGeneratorLibrary;
using UnityEngine;

namespace VirtualPets.Scripts
{
    public class PetName : MonoBehaviour
    {
        public string Name { get; private set; }
    
        // Start is called before the first frame update
        void Start()
        {
            Name = GenerateRandomName();
        }

        string GenerateRandomName()
        {
            return "<ANIMAL>";
        }
    }
}
