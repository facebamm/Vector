using System;
namespace FaceMaterial.Terrain
{
    [Flags]
    public enum CompareResult
    {
        Identical,
        Parallel,
        Intersect,
        Perpendicular,
        Skew
    }
}
