using System.Collections.Generic;
using UnityEngine;
namespace Town.Geom
{
    public class Vector2LengthComparer : IComparer<Vector2>
    {
        public int Compare(Vector2 x, Vector2 y)
        {
            return x.sqrMagnitude.CompareTo(y.sqrMagnitude);
        }
    }
}