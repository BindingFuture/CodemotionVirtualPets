using TMPro;
using UnityEngine;

namespace VirtualPets.Scripts
{
    [RequireComponent(typeof(TMP_Text))]
    public class PetNameDisplay : MonoBehaviour
    {
        private TMP_Text _text;

        void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            ClearName();
        }

        public void UpdateName(GameObject go)
        {
            _text.enabled = true;
            _text.text = go.GetComponent<PetName>().Name;
        }

        public void ClearName()
        {
            _text.enabled = false;
        }
    }
}
