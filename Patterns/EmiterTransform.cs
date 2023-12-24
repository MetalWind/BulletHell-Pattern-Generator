using UnityEngine;

public struct EmiterTransform
{
    public Vector2 position;
    public float zRotation;

    public EmiterTransform(Vector2 position, float zRotation)
    {
        this.position = position;
        this.zRotation = zRotation;
    }
}
