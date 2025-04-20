using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public enum AxisPair {
    xy,
    xz,
    yz,
    yx,
    zx,
    zy
}

public static class Utilities
{
    public static Vector2 Vector3ToVector2(Vector3 vector, AxisPair pair) {
        if (pair == AxisPair.xy) {
            return new Vector2(vector.x, vector.y);
        } else if (pair == AxisPair.xz) {
            return new Vector2(vector.x, vector.z);
        } else if (pair == AxisPair.yz) {
            return new Vector2(vector.y, vector.z);
        } else if (pair == AxisPair.yx) {
            return new Vector2(vector.y, vector.x);
        } else if (pair == AxisPair.zx) {
            return new Vector2(vector.z, vector.x);
        } else if (pair == AxisPair.zy) {
            return new Vector2(vector.z, vector.y);
        } else {
            return Vector2.zero;
        }
    }

    public static Vector2 MapVector(Vector2 input, System.Func<float, float> func) {
        Vector2 output = new Vector2(func(input.x), func(input.y));
        return output;
    }

    public static Vector3 MapVector(Vector3 input, System.Func<float, float> func) {
        Vector3 output = new Vector3(func(input.x), func(input.y), func(input.z));
        return output;
    }

    public static Vector2Int MapVector(Vector2Int input, System.Func<int, int> func) {
        Vector2Int output = new Vector2Int(func(input.x), func(input.y));
        return output;
    }

    public static Vector3Int MapVector(Vector3Int input, System.Func<int, int> func) {
        Vector3Int output = new Vector3Int(func(input.x), func(input.y), func(input.z));
        return output;
    }
}
