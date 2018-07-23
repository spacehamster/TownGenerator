using System;
using UnityEngine;
namespace Town.Geom
{
    public static class GeometryHelpers
    {
        public static Vector2 IntersectLines(float x1, float y1, float dx1, float dy1, float x2, float y2, float dx2,
            float dy2)
        {
            var d = dx1 * dy2 - dy1 * dx2;
            if (Math.Abs(d) < 0.01)
            {
                return new Vector2(float.MaxValue, float.MaxValue);
            }

            var t2 = (dy1 * (x2 - x1) - dx1 * (y2 - y1)) / d;
            var t1 = Math.Abs(dx1) > 0.0001 ? (x2 - x1 + dx2 * t2) / dx1 : (y2 - y1 + dy2 * t2) / dy1;

            return new Vector2(t1, t2);
        }

        public static Vector2 Interpolate(Vector2 p1, Vector2 p2, float ratio = 0.5f)
        {
            var d = p2 - p1;
            return new Vector2(p1.x + d.x * ratio, p1.y + d.y * ratio);
        }

        //public static inline function scalar(x1:Float, y1:Float, x2:Float, y2:Float )
        //return x1* x2 + y1* y2;

        public static float CrossProduct(float x1, float y1, float x2, float y2)
        {
            return x1 * y2 - y1 * x2;
        }

        public static float DistanceToLine(Vector2 a, Vector2 b, Vector2 p)
        {
            var ap = p - a;
            var ab = b - a;

            return Vector2.Dot(ap, ab) / (ab.magnitude * ab.magnitude);
        }
        public static float Cross(Vector2 a, Vector2 b)
        {
            return GeometryHelpers.CrossProduct(a.x, a.y, b.x, b.y);
        }
        public static Vector2 SmoothVertex(Vector2 vertex, Vector2 prev, Vector2 next, float amount = 1f)
        {
            return new Vector2((prev.x + vertex.x * amount + next.x) / (2 + amount),
                (prev.y + vertex.y * amount + next.y) / (2 + amount));
        }
        public static float Angle(Vector2 vec)
        {
            return AngleThreePoints(vec, Vector2.zero, Vector2.right);
        }
        public static float AngleThreePoints(Vector2 a, Vector2 b, Vector2 c)
        {
            var v1 = b - a;
            var v2 = c - b;
            var cross = GeometryHelpers.Cross(v1, v2);
            var dot = Vector2.Dot(v1, v2);
            return (float)Math.Atan2(cross, dot);
        }
        public static Vector2 Rotate90(Vector2 a)
        {
            return new Vector2(-a.y, a.x);
        }
        public static Vector2 Normalize(Vector2 a)
        {
            return a.normalized;
        }
        public static Vector2 Scale(Vector2 a, float factor)
        {
            return a * factor;
        }
        public static Vector2 RotateAoundPoint(Vector2 point, Vector2 center, float angle)
        {
            var cosTheta = Math.Cos(angle);
            var sinTheta = Math.Sin(angle);
            var newX = (cosTheta * (point.x - center.x) - sinTheta * (point.y - center.y) + center.x);
            var newY = (sinTheta * (point.x - center.x) + cosTheta * (point.y - center.y) + center.y);
            return new Vector2((float)newX, (float)newY);
        }
        public static float AngleComparedTo(Vector2 first, Vector2 other)
        {
            return AngleThreePoints(first, Vector2.zero, other);
        }

    }
}