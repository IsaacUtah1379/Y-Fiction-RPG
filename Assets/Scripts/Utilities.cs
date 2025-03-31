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
}
