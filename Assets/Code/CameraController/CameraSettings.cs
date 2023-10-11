using UnityEngine;

namespace Code.CameraController
{
    [CreateAssetMenu(order = 3, fileName = "CameraSettings", menuName = "CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        [SerializeField] float _xOffset;
        [SerializeField] float _yOffset; 
        [SerializeField] protected float _followSpeed;
        [SerializeField] private Camera _camera;

        public float Xoffset => _xOffset;
        public float Yoffset => _yOffset;
        public float FollowSpeed => _followSpeed;

        public Camera Camera => _camera;
    }
}
