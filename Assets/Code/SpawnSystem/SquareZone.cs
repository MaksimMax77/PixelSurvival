using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.SpawnSystem
{
    public class SquareZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _squareField;
        [SerializeField] private Vector3 _center;
        public Vector3 GetRandomPosInSquare()
        {
            var pos = _center + new Vector3(
                Random.Range(-_squareField.x / 2, _squareField.x / 2),
                Random.Range(-_squareField.y / 2, _squareField.y / 2),
                Random.Range(-_squareField.z / 2, _squareField.z / 2));
            return pos;
        }

        public Vector3 GetClampedPos(Vector3 pos)
        {
            var minX = _center.x + -_squareField.x / 2;
            var maxX = _center.x + _squareField.x / 2;
            var minY = _center.y + -_squareField.y / 2;
            var maxY = _center.y + _squareField.y / 2;
            
            var x= Mathf.Clamp(pos.x, minX, maxX);
            var y= Mathf.Clamp(pos.y, minY, maxY);
            return pos = new Vector3(x, y);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0.2f, 0, 0.5f);
            Gizmos.DrawCube(transform.localPosition + _center, _squareField);
        }
    }
}
