using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Projectile))]
public class DefaultMove : ProjectileModifierBase
{
    private Projectile _projectile;
    private Rigidbody2D _rb;
    private ProjectileModel _projectileModel;

    public override void Initialize(Projectile projectile)
    {
        _projectile = projectile;
        _rb = GetComponent<Rigidbody2D>();
        _projectileModel = _projectile.model;
        _projectileModel.lookDirection = Mathf.Atan2(_projectileModel.velocity.x, _projectileModel.velocity.y);
    }

    public override void DoNextModifierStep()
    {
        _projectileModel.velocity += _projectileModel.acceleration;
        _rb.velocity = _projectileModel.velocity;
        _rb.rotation = _projectileModel.lookDirection;

        _projectileModel.RemoveValues();
    }
}
