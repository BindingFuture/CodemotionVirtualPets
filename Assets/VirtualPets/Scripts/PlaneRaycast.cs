using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace VirtualPets.Scripts
{
    [RequireComponent(typeof(ARRaycastManager))]
    [RequireComponent(typeof(ARPlaneManager))]
    public class PlaneRaycast : MonoBehaviour
    {
        private ARPlaneManager _planeManager;
        private ARAnchorManager _anchorManager;
        private ARRaycastManager _raycastManager;

        private ARRaycast _screenCenterRaycast;

        private readonly List<ARRaycastHit> _hits = new();

        public UnityEvent<Transform, Kind> onPlaneHitFound = new();
        
        private readonly Vector3 _viewPortCenter = new Vector3(0.5f, 0.5f);

        [SerializeField]
        private Camera rayCamera;
        
        void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            _anchorManager = GetComponent<ARAnchorManager>();
            _planeManager = GetComponent<ARPlaneManager>();
            
            if(!rayCamera) 
                rayCamera = Camera.main;
        }

        public void RaycastPlaneCat() => RaycastPlane(Kind.Cat);

        public void RaycastPlaneDog() => RaycastPlane(Kind.Dog);
        
        public void RaycastPlane(Kind kind)
        {
            var rayStart = rayCamera.ViewportToScreenPoint(_viewPortCenter);
            
            if (!_raycastManager.Raycast(rayStart, _hits, TrackableType.PlaneWithinPolygon)) 
                return;
            
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = _hits[0].pose;
            var hitTrackableId = _hits[0].trackableId;
            var hitPlane = _planeManager.GetPlane(hitTrackableId);
                
            // This attaches an anchor to the area on the plane corresponding to the raycast hit
            var anchor = _anchorManager.AttachAnchor(hitPlane, hitPose);

            if (anchor)
            {
                onPlaneHitFound.Invoke(anchor.transform, kind);
            }
            else
            {
                Debug.Log("Error creating anchor.");
            }
        }
    }
}