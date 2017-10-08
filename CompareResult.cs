using System;
namespace FaceMaterial.Vector
{
    [Flags]
    public enum CompareResult
    {
        Identical,
        Parallel,
        Intersect,
        Skew
    }
}
