using UnityEngine;

namespace Code.ObjectMove
{
    public class OnDirectionMover
    {
        public static bool Move(GameObject moveObject, Vector3 targetPos, float moveSpeed)
        {
            if (moveObject == null)
            {
                return false;
            }
            
            var position = moveObject.transform.position;
            
            if (DistanceChecker.CheckDistance(targetPos, position, 0.1f))
            {
                return false;
            }
            var dir = DistanceChecker.GetDirection(targetPos, position).normalized 
                      * moveSpeed * Time.deltaTime;
            position += dir;
            moveObject.transform.position = position;
            return true;
        }
    }
}
