using UnityEngine;

public class DefaultMove : ProjectileModifierBase
{
    [SerializeField] private float velocity;

    private ProjectileModel _model;
    private Vector2 _initialDirection;

    public override void Initialize(Projectile projectile)
    {
        _model = projectile.model;
        _initialDirection = _model.velocity.normalized;
    }

    public override void DoNextModifierStep()
    {
        _model.velocity += _initialDirection * velocity;
    }
}
