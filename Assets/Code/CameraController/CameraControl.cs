using Code.GOControl;
using Code.Update;
using UnityEngine;
using Zenject;

namespace Code.CameraController
{
    public class CameraControl: UpdateObject
    {
        private Transform _target;
        private float _xOffset;
        private float _yOffset; 
        private float _followSpeed;
        private Camera _camera;
        private CameraSettings _cameraSettings;
        private GameObjectsControl _gameObjectsControl;

        [Inject]
        public CameraControl(GameObjectsControl gameObjectsControl, Updater updater, CameraSettings cameraSettings) : base(updater)
        {
            _cameraSettings = cameraSettings;
            _xOffset = cameraSettings.Xoffset;
            _yOffset = cameraSettings.Yoffset;
            _followSpeed = cameraSettings.FollowSpeed;
            _gameObjectsControl = gameObjectsControl;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _camera = _gameObjectsControl.GoInstantiate(ObjectType.Camera, _cameraSettings.Camera);
        }
        
        public override void Update()
        {
            if (_target == null)
            {
                return;
            }
            var transform = _camera.transform;
            var xTarget = _target.position.x + _xOffset;
            var yTarget = _target.position.y + _yOffset;

            var xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * _followSpeed);
            var yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * _followSpeed);

            transform.position = new Vector3(xNew, yNew, transform.position.z);
        }
    }
}