using UnityEngine;

namespace Code.ObjectMove
{
    public static class DistanceChecker
    {
        public static bool CheckDistance(Vector3 targetPos, Vector3 currentPos, float minDistance)
        {
            return GetDirection(targetPos, currentPos).magnitude <= minDistance;
        }
        public static Vector3 GetDirection(Vector3 targetPos, Vector3 currentPos)
        {
            return targetPos - currentPos;
        }
    }
}
