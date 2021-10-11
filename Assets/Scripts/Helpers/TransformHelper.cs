using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public static class TransformHelper
    {
        public static Transform FindNear(Transform fromTransform, List<Transform> toTransforms)
        {
            var playerPosition = fromTransform.position;
            
            float distance = -1f;
            Transform lastTarget = null;
            
            foreach (var point in toTransforms)
            {
                var enemyPosition = point.position;
                var dirPosition = enemyPosition - playerPosition;

                if (distance < 0 || dirPosition.magnitude < distance)
                {
                    distance = dirPosition.magnitude;
                    lastTarget = point;
                }
            }

            return lastTarget;
        }
    }
}