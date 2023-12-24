using UnityEngine;

public class ProjectileModel
{
    public Vector2 velocity;
    public Vector2 acceleration;
    public float lookDirection;

    public ProjectileModel(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    public ProjectileModel(Vector2 velocity, Vector2 acceleration, float lookDirection)
    {
        this.velocity = velocity;
        this.acceleration = acceleration;
        this.lookDirection = lookDirection;
    }

    public ProjectileModel Copy()
    {
        return new ProjectileModel(velocity, acceleration, lookDirection);
    }

    public void RemoveValues()
    {
        velocity = Vector2.zero;
        acceleration = Vector2.zero;
    }
}
