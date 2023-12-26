using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Projectile))]
public class MoveApplier : ProjectileModifierBase
{
    private Projectile _projectile;
    private Rigidbody2D _rb;
    private ProjectileModel _projectileModel;

    public override void Initialize(Projectile projectile)
    {
        _projectile = projectile;
        _projectileModel = _projectile.model;
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void DoNextModifierStep()
    {
        _projectileModel.velocity += _projectileModel.acceleration;
        _rb.velocity = _projectileModel.velocity;
        _rb.rotation = _projectileModel.lookDirection;

        _projectileModel.RemoveValues();
    }
}
