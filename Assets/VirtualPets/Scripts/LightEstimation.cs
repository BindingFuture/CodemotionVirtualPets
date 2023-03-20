using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;

namespace VirtualPets.Scripts
{
    [RequireComponent(typeof(Light))]
    public class LightEstimation : MonoBehaviour
    {
        [SerializeField]
        private ARCameraManager arCameraManager;
        
        private Light _light;
        
        /// <summary>
        /// The estimated brightness of the physical environment, if available.
        /// </summary>
        public float? Brightness { get; private set; }

        /// <summary>
        /// The estimated color temperature of the physical environment, if available.
        /// </summary>
        public float? ColorTemperature { get; private set; }

        /// <summary>
        /// The estimated color correction value of the physical environment, if available.
        /// </summary>
        public Color? ColorCorrection { get; private set; }
    
        // Start is called before the first frame update
        void Awake()
        {
            _light = GetComponent<Light>();
        }

        private void OnEnable()
        {
            arCameraManager.frameReceived += OnFrameReceived;
        }

        private void OnDisable()
        {
            arCameraManager.frameReceived -= OnFrameReceived;
        }

        private void OnFrameReceived(ARCameraFrameEventArgs args)
        {
            if (args.lightEstimation.averageBrightness.HasValue)
            {
                Brightness = args.lightEstimation.averageBrightness.Value;
                _light.intensity = Brightness.Value;
            }
            else
            {
                Brightness = null;
            }

            if (args.lightEstimation.averageColorTemperature.HasValue)
            {
                ColorTemperature = args.lightEstimation.averageColorTemperature.Value;
                _light.colorTemperature = ColorTemperature.Value;
            }
            else
            {
                ColorTemperature = null;
            }

            if (args.lightEstimation.colorCorrection.HasValue)
            {
                ColorCorrection = args.lightEstimation.colorCorrection.Value;
                _light.color = ColorCorrection.Value;
            }
            else
            {
                ColorCorrection = null;
            }
        }
    }
}
