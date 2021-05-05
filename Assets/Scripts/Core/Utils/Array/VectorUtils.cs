using UnityEngine;

namespace Core.Utils.Array
{
    public static class VectorUtils
    {
        private const float MinTolerance = 0.09f;
        
        public static bool IsEqualsZero(this Vector2 vector2)
        {
            return IsEqualZero(vector2.x) && IsEqualZero(vector2.y);
        }
        
        public static bool IsEquals(this Vector2 left, Vector2 right, float minTolerance = 0.1f)
        {
            return IsEquals(left.x, right.x,minTolerance) && IsEquals(left.y, right.y, minTolerance);
        }
        
        
        public static bool IsEqualZero(this float value, float minTolerance = MinTolerance)
        {
            return Mathf.Abs(value) < minTolerance;
        }

        public static Vector2 VectorOne(this Vector2 vector2)
        {
            if (!vector2.x.IsEqualZero()) vector2.x = vector2.x > 0 ? 1 : -1;
            if (!vector2.y.IsEqualZero()) vector2.y = vector2.y > 0 ? 1 : -1;
            return vector2;
        }

        public static Vector2 Random(this Vector2 vector2)
        {
            vector2.x = UnityEngine.Random.Range(-vector2.x, vector2.x);
            vector2.y = UnityEngine.Random.Range(-vector2.y, vector2.y);
            return vector2;
        }
        
        public static bool IsEquals(this Vector3 vector2, Vector3 anotherVector, float minTolerance = MinTolerance)
        {
            return IsEquals(vector2.x, anotherVector.x) && IsEquals(vector2.y, anotherVector.y);
        }
        
        public static bool IsEquals(this float floatLeft, float floatRight, float minTolerance = MinTolerance)
        {
            return Mathf.Abs(floatLeft - floatRight) < minTolerance;
        }

        public static void RotateToDirection(this Transform transform, Vector2 direction)
        {
            var position = transform.position;
            Vector3 diff = position +(Vector3) direction - position;
            diff.Normalize();
 
            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
        
        public static Vector2 FromCanvasToWorld(this RectTransform canvasTransform, Vector2 canvasPosition)
        {
            Canvas.ForceUpdateCanvases();
            return canvasTransform.TransformPoint(canvasPosition);
        }

        public static Vector2 Lerp(Vector2 start, Vector2 end, float timeStartedLerp, float lerpTime = 1)
        {
            float timeSinceStarted = Time.time - timeStartedLerp;
            // if (timeSinceStarted >= lerpTime)
            // {
            //     return end;
            // }
            float percentageComplete = timeSinceStarted / lerpTime;
            return Vector2.Lerp(start, end, percentageComplete);
        }
    }
}
