using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class SinInLine : ProjectileModifierBase
{
    [SerializeField] private float _amplitude= 0.5f;
    [SerializeField] private float _frequency = 2;
    private float x;
    private ProjectileModel _model;
    private Vector2 _startDirection;

    public override void DoNextModifierStep()
    {
        x += Time.fixedDeltaTime;
        float y = _amplitude * Mathf.Sin(x * _frequency);
        _model.velocity += y * _startDirection;
    }

    public override void Initialize(Projectile projectile)
    {
        _model = projectile.model;
        _startDirection = _model.velocity;
    }
}
