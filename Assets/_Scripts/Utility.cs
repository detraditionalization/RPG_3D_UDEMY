using UnityEngine;

public enum Layer
{
    Walkable = 8,
    Enemy = 9,
    RaycastEndStop = -1
}


public static class Utility
{


    public static float Map(float x, float xMin, float xMax, float yMin = 0f, float yMax = 1f, float pow = 1f)
    {
        var p = (x - xMin) / (xMax - xMin);
        return Mathf.Pow(p,pow) * (yMax - yMin) + yMin;
    }

    public static float InverseMap(float x, float xMin, float xMax, float yMin = 0f, float yMax = 1f, float pow = 1f)
    {
        var p = (x - xMin) / (xMax - xMin);
        return Mathf.Pow((1f - p), pow) * (yMax - yMin) + yMin;
    }
}

